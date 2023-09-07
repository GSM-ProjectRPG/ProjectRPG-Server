using System.Linq;
using System.Collections.Generic;
using ProjectRPG.Job;

namespace ProjectRPG.Game
{
    public partial class GameRoom : JobSerializer
    {
        public const int VisionCells = 5;

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
        }

        public void Update()
        {
            Flush();
        }

        public void EnterGame(GameObject gameObject, bool isRandomPos)
        {

        }

        public void LeaveGame(int gameObjectId)
        {

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
    }
}