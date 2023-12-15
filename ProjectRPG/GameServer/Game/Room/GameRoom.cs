using System;
using System.Linq;
using System.Collections.Generic;
using Google.Protobuf;
using Google.Protobuf.Protocol;
using GameServer.Job;

namespace GameServer.Game
{
    public partial class GameRoom : JobSerializer
    {
        public const int VisionCells = 30;

        public int RoomId { get; set; }

        public Map Map { get; private set; } = new Map();
        public Zone[,] Zones { get; private set; }
        public int ZoneCells { get; private set; }

        private Dictionary<int, Player> _players = new Dictionary<int, Player>();
        private Dictionary<int, Monster> _monsters = new Dictionary<int, Monster>();

        public void Init(int mapId, int zoneCells)
        {
            Map.LoadMap(mapId);

            // Zone 초기화
            ZoneCells = zoneCells;
            int zoneCountY = (Map.SizeY + zoneCells - 1) / zoneCells;
            int zoneCountX = (Map.SizeX + zoneCells - 1) / zoneCells;
            Zones = new Zone[zoneCountY, zoneCountX];
            for (int y = 0; y < zoneCountY; y++)
                for (int x = 0; x < zoneCountX; x++)
                    Zones[y, x] = new Zone(y, x);

            var slime = ObjectManager.Instance.Add<Monster>();
            slime.Init(0);
            EnterGame(slime);
        }

        public void Update()
        {
            Flush();
        }

        /// <summary>
        /// 시야 범위 내의 플레이어들에게 Broadcast하는 함수
        /// </summary>
        /// <param name="pos">기준 위치</param>
        /// <param name="packet">보낼 패킷</param>
        public void Broadcast(Vector2Int pos, IMessage packet)
        {
            var zones = GetZonesInRange(pos);

            foreach (var player in zones.SelectMany(z => z.Players))
            {
                int dx = player.CellPos.x - pos.x;
                int dy = player.CellPos.y - pos.y;
                if (Math.Abs(dx) > VisionCells) continue;
                if (Math.Abs(dy) > VisionCells) continue;
                player.Session.Send(packet);
            }
        }

        /// <summary>
        /// GameRoom 입장 함수
        /// </summary>
        /// <param name="gameObject">입장할 GameObject</param>
        /// <param name="isRandomPos"></param>
        public void EnterGame(GameObject gameObject)
        {
            if (gameObject == null) return;

            ObjectSpawner.Spawn(gameObject);

            var type = ObjectManager.GetObjectTypeById(gameObject.Id);
            if (type == GameObjectType.Player)
            {
                var player = (Player)gameObject;
                _players.Add(gameObject.Id, player);
                player.CurrentRoom = this;
                
                GetZone(player.CellPos).Players.Add(player);
                Map.ApplyMove(player, new Vector2Int(player.CellPos.x, player.CellPos.y));

                // 본인에게 정보 전송
                {
                    var enterGamePacket = new S_EnterGame();
                    enterGamePacket.Player = player.Info;
                    player.Session.Send(enterGamePacket);
                    player.Vision.Update();
                    player.Update();
                }
            }
            else if (type == GameObjectType.Monster)
            {
                var monster = (Monster)gameObject;
                _monsters.Add(gameObject.Id, monster);
                monster.CurrentRoom = this;

                GetZone(monster.CellPos).Monsters.Add(monster);
                Map.ApplyMove(monster, new Vector2Int(monster.CellPos.x, monster.CellPos.y));
                monster.Update();
            }

            // 타인에게 정보 전송
            {
                var spawnPacket = new S_Spawn();
                spawnPacket.Objects.Add(gameObject.Info);
                Broadcast(gameObject.CellPos, spawnPacket);
            }
        }

        /// <summary>
        /// GameRoom 퇴장 함수
        /// </summary>
        /// <param name="gameObjectId">퇴장할 GameObject ID</param>
        public void LeaveGame(int gameObjectId)
        {
            var type = ObjectManager.GetObjectTypeById(gameObjectId);
            Vector2Int cellPos;

            if (type == GameObjectType.Player)
            {
                if (_players.Remove(gameObjectId, out var player) == false)
                    return;

                cellPos = player.CellPos;
                Map.ApplyLeave(player);
                player.CurrentRoom = null;

                // 본인에게 정보 전송
                var leaveGamePacket = new S_LeaveGame();
                player.Session.Send(leaveGamePacket);
            }
            else if (type == GameObjectType.Monster)
            {
                if (_monsters.Remove(gameObjectId, out var monster) == false)
                    return;

                cellPos = monster.CellPos;
                Map.ApplyLeave(monster);
                monster.CurrentRoom = null;
            }
            else return;

            // 타인에게 정보 전송
            var despawnPacket = new S_Despawn();
            despawnPacket.ObjectIds.Add(gameObjectId);
            Broadcast(cellPos, despawnPacket);
        }

        /// <summary>
        /// 위치를 이용하여 Zone을 가져오는 함수
        /// </summary>
        /// <param name="cellPos">기준 위치</param>
        /// <returns>Zone</returns>
        public Zone GetZone(Vector2Int cellPos)
        {
            int x = (cellPos.x - Map.MinX) / ZoneCells;
            int y = (Map.MaxY - cellPos.y) / ZoneCells;
            return GetZone(y, x);
        }

        /// <summary>
        /// 인덱스를 이용하여 Zone을 가져오는 함수
        /// </summary>
        /// <param name="indexY">y index</param>
        /// <param name="indexX">x index</param>
        /// <returns>Zone</returns>
        public Zone GetZone(int indexY, int indexX)
        {
            if (indexX < 0 || indexX >= Zones.GetLength(1)) return null;
            if (indexY < 0 || indexY >= Zones.GetLength(0)) return null;
            return Zones[indexY, indexX];
        }

        /// <summary>
        /// 가장 가까운 Player를 반환하는 함수
        /// </summary>
        /// <param name="pos">기준 위치</param>
        /// <param name="range">범위</param>
        /// <returns>Player</returns>
        public Player FindClosestPlayer(Vector2Int pos, int range)
        {
            var players = GetPlayersInRange(pos, range);

            players.Sort((left, right) =>
            {
                int leftDist = (left.CellPos - pos).cellDistFromZero;
                int rightDist = (right.CellPos - pos).cellDistFromZero;
                return 0;
            });

            foreach (var player in players)
            {
                var path = Map.FindPath(pos, player.CellPos, checkObjects: true);
                if (path.Count < 2 || path.Count > range)
                    continue;

                return player;
            }

            return null;
        }

        /// <summary>
        /// 범위 안의 Player들을 반환하는 함수
        /// </summary>
        /// <param name="pos">기준 위치</param>
        /// <param name="range">범위</param>
        /// <returns>Player 리스트</returns>
        public List<Player> GetPlayersInRange(Vector2Int pos, int range)
        {
            var zones = GetZonesInRange(pos, range);
            return zones.SelectMany(z => z.Players).ToList();
        }

        /// <summary>
        /// 범위 안의 Zone들을 반환하는 함수
        /// </summary>
        /// <param name="pos">기준 위치</param>
        /// <param name="range">범위</param>
        /// <returns>Zone 리스트</returns>
        public List<Zone> GetZonesInRange(Vector2Int pos, int range = VisionCells)
        {
            var zones = new HashSet<Zone>();
            int minY = pos.y - range;
            int maxY = pos.y + range;
            int minX = pos.x - range;
            int maxX = pos.x + range;

            // 좌측 상단 좌표 계산
            var leftTop = new Vector2Int(minX, maxY);
            int minEdgeY = (Map.MaxY - leftTop.y) / ZoneCells;
            int minEdgeX = (leftTop.x - Map.MinX) / ZoneCells;

            // 우측 하단 좌표 계산
            var rightBottom = new Vector2Int(maxX, minY);
            int maxEdgeY = (Map.MaxY - rightBottom.y) / ZoneCells;
            int maxEdgeX = (rightBottom.x - Map.MinX) / ZoneCells;

            for (int x = minEdgeX; x <= maxEdgeX; x++)
            {
                for (int y = minEdgeY; y <= maxEdgeY; y++)
                {
                    var zone = GetZone(y, x);
                    if (zone != null)
                        zones.Add(zone);
                }
            }

            return zones.ToList();
        }

        private void BroadcastAll(IMessage packet)
        {
            foreach (var player in _players.Values)
            {
                player.Session.Send(packet);
            }
        }
    }
}