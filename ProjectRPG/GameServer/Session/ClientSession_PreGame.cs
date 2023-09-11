using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ACore;
using Google.Protobuf.Protocol;
using ProjectRPG.Game;
using ProjectRPG.DB;
using ProjectRPG.Data;

namespace ProjectRPG
{
    public partial class ClientSession : PacketSession
    {
        public int AccountDbId { get; private set; }
        public List<LobbyPlayerInfo> LobbyPlayers { get; set; } = new List<LobbyPlayerInfo>();

        public void HandleLogin(C_Login loginPacket)
        {
            if (ServerState != PlayerServerState.Login) return;

            LobbyPlayers.Clear();

            using (var db = new AppDbContext())
            {
                var findAccount = db.Accounts
                    .Include(a => a.Players)
                    .Where(a => a.AccountName == loginPacket.UniqueId)
                    .FirstOrDefault();

                if (findAccount != null)
                {
                    // AccountDbId 메모리에 저장
                    AccountDbId = findAccount.AccountDbId;

                    var loginOk = new S_Login() { LoginOk = 1 };

                    foreach (var playerDb in findAccount.Players)
                    {
                        var lobbyPlayer = new LobbyPlayerInfo()
                        {
                            PlayerDbId = playerDb.PlayerDbId,
                            Name = playerDb.PlayerName,
                            Stat = new StatInfo()
                            {
                                Level = playerDb.Level,
                                Hp = playerDb.Hp,
                                MaxHp = playerDb.MaxHp,
                                AtkPower = playerDb.AtkPower,
                                Speed = playerDb.Speed,
                                TotalExp = playerDb.TotalExp
                            }
                        };

                        // 메모리에 저장
                        LobbyPlayers.Add(lobbyPlayer);

                        // 패킷에 추가
                        loginOk.Players.Add(lobbyPlayer);
                    }

                    Send(loginOk);

                    ServerState = PlayerServerState.Lobby;
                }
                else
                {
                    var newAccount = new AccountDb() { AccountName = loginPacket.UniqueId };
                    db.Accounts.Add(newAccount);
                    bool success = db.SaveChangesEx();
                    if (success == false)
                        return;

                    // AccountDbId 메모리에 저장
                    AccountDbId = newAccount.AccountDbId;

                    var loginOk = new S_Login() { LoginOk = 1 };
                    Send(loginOk);

                    ServerState = PlayerServerState.Lobby;
                }
            }
        }

        public void HandleCreatePlayer(C_CreatePlayer createPlayerPacket)
        {
            if (ServerState != PlayerServerState.Lobby) return;

            using (var db = new AppDbContext())
            {
                var findPlayer = db.Players
                    .Where(p => p.PlayerName == createPlayerPacket.Name).FirstOrDefault();

                if (findPlayer != null)
                {
                    // 이름 중복 시 빈 패킷 반환
                    Send(new S_CreatePlayer());
                }
                else
                {
                    // 1레벨 Stat 정보 추출
                    DataManager.StatDict.TryGetValue(1, out var stat);

                    // DB에 저장
                    var newPlayerDb = new PlayerDb()
                    {
                        PlayerName = createPlayerPacket.Name,
                        Level = stat.Level,
                        Hp = stat.Hp,
                        MaxHp = stat.MaxHp,
                        AtkPower = stat.AtkPower,
                        Speed = stat.Speed,
                        TotalExp = 0,
                        AccountDbId = AccountDbId
                    };

                    db.Players.Add(newPlayerDb);

                    bool isCompleted = db.SaveChangesEx();
                    if (isCompleted == false)
                        return;

                    // 메모리에도 저장
                    var lobbyPlayer = new LobbyPlayerInfo()
                    {
                        PlayerDbId = newPlayerDb.PlayerDbId,
                        Name = createPlayerPacket.Name,
                        Stat = new StatInfo()
                        {
                            Level = stat.Level,
                            Hp = stat.Hp,
                            MaxHp = stat.MaxHp,
                            AtkPower = stat.AtkPower,
                            Speed = stat.Speed,
                            TotalExp = 0
                        }
                    };

                    LobbyPlayers.Add(lobbyPlayer);

                    var newPlayerPacket = new S_CreatePlayer() { Player = new LobbyPlayerInfo() };
                    newPlayerPacket.Player.MergeFrom(lobbyPlayer);
                    Send(newPlayerPacket);
                }
            }
        }

        public void HandleEnterGame(C_EnterGame enterGamePacket)
        {
            if (ServerState != PlayerServerState.Lobby) return;

            var playerInfo = LobbyPlayers.Find(p => p.Name == enterGamePacket.Name);
            if (playerInfo == null) return;

            MyPlayer = ObjectManager.Instance.Add<Player>();
            MyPlayer.PlayerDbId = playerInfo.PlayerDbId;
            MyPlayer.Info.Name = playerInfo.Name;
            MyPlayer.Info.Transform.State = CreatureState.Idle;
            MyPlayer.Stat.MergeFrom(playerInfo.Stat);
            MyPlayer.Session = this;

            var itemListPacket = new S_ItemList();

            using (var db = new AppDbContext())
            {
                var items = db.Items
                    .Where(i => i.OwnerDbId == playerInfo.PlayerDbId)
                    .ToList();

                foreach (var itemDb in items)
                {
                    var item = Item.MakeItem(itemDb);
                    if (item != null)
                    {
                        MyPlayer.Inven.Add(item);
                        var info = new ItemInfo();
                        info.MergeFrom(item.Info);
                        itemListPacket.Items.Add(info);
                    }
                }
            }

            Send(itemListPacket);

            ServerState = PlayerServerState.Game;

            GameLogic.Instance.Push(() =>
            {
                var room = GameLogic.Instance.FindRoom(1);
                room.Push(room.EnterGame, MyPlayer, true);
            });
        }
    }
}