using System.Collections.Generic;
using Google.Protobuf.Protocol;
using ACore;
using ProjectRPG.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
    }
}