using System;
using System.IO;
using System.Collections.Generic;
using Google.Protobuf.Protocol;
using ACore;

namespace ProjectRPG.Game
{
    public class Map
    {
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        public int SizeX { get => MaxX - MinX + 1; }
        public int SizeY { get => MaxY - MinY + 1; }

        private bool[,] _collision;
        private GameObject[,] _objects;

        /// <summary>
        /// 특정 위치로 이동 가능 여부를 확인하는 함수
        /// </summary>
        /// <param name="cellPos">이동할 위치</param>
        /// <param name="checkObjects">오브젝트(장애물) 확인 여부</param>
        /// <returns>이동 가능 여부</returns>
        public bool CanGo(Vector2Int cellPos, bool checkObjects = true)
        {
            if (cellPos.x < MinX || cellPos.x > MaxX) return false;
            if (cellPos.y < MinY || cellPos.y > MaxY) return false;

            int x = cellPos.x - MinX;
            int y = MaxY - cellPos.y;
            return !_collision[y, x] && (!checkObjects || _objects[y, x] == null);
        }

        /// <summary>
        /// 특정 위치의 GameObject를 반환하는 함수
        /// </summary>
        /// <param name="cellPos">탐색 위치</param>
        /// <returns>GameObject</returns>
        public GameObject Find(Vector2Int cellPos)
        {
            if (cellPos.x < MinX || cellPos.x > MaxX) return null;
            if (cellPos.y < MinY || cellPos.y > MaxY) return null;

            int x = cellPos.x - MinX;
            int y = MaxY - cellPos.y;
            return _objects[y, x];
        }

        /// <summary>
        /// GameObject가 GameRoom에서 퇴장 시 실행하는 함수
        /// </summary>
        /// <param name="gameObject">GameRoom에서 나가는 GameObject</param>
        /// <returns>퇴장 성공 여부</returns>
        public bool ApplyLeave(GameObject gameObject)
        {
            if (gameObject.CurrentRoom == null) return false;
            if (gameObject.CurrentRoom.Map != this) return false;

            var transform = gameObject.Transform;
            if (transform.Position.X < MinX || transform.Position.X > MaxX) return false;
            if (transform.Position.Z < MinY || transform.Position.Z > MaxY) return false;

            var zone = gameObject.CurrentRoom.GetZone(gameObject.CellPos);
            zone.Remove(gameObject);

            int x = (int)transform.Position.X - MinX;
            int y = MaxY - (int)transform.Position.Z;
            if (_objects[y, x] == gameObject)
                _objects[y, x] = null;

            return true;
        }

        /// <summary>
        /// GameObject의 위치 이동 검증을 위한 함수
        /// </summary>
        /// <param name="gameObject">이동하는 GameObject</param>
        /// <param name="dest">목적지</param>
        /// <param name="checkObjects">오브젝트(장애물) 확인 여부</param>
        /// <param name="collision">충돌 확인 여부</param>
        /// <returns>이동 성공 여부</returns>
        public bool ApplyMove(GameObject gameObject, Vector2Int dest, bool checkObjects = true, bool collision = true)
        {
            if (gameObject.CurrentRoom == null) return false;
            if (gameObject.CurrentRoom.Map != this) return false;

            var transform = gameObject.Transform;
            if (CanGo(dest, checkObjects) == false)
                return false;

            if (collision)
            {
                {
                    int x = (int)transform.Position.X - MinX;
                    int y = MaxY - (int)transform.Position.Z;
                    if (_objects[y, x] == gameObject)
                        _objects[y, x] = null;
                }

                {
                    int x = dest.x - MinX;
                    int y = MaxY - dest.y;
                    _objects[y, x] = gameObject;
                }
            }

            var type = ObjectManager.GetObjectTypeById(gameObject.Id);
            if (type == GameObjectType.Player)
            {
                var player = (Player)gameObject;
                var currentZone = gameObject.CurrentRoom.GetZone(gameObject.CellPos);
                var afterZone = gameObject.CurrentRoom.GetZone(dest);
                if (currentZone != afterZone)
                {
                    currentZone.Players.Remove(player);
                    afterZone.Players.Add(player);
                }
            }
            else if (type == GameObjectType.Monster)
            {
                var monster = (Monster)gameObject;
                var currentZone = gameObject.CurrentRoom.GetZone(gameObject.CellPos);
                var afterZone = gameObject.CurrentRoom.GetZone(dest);
                if (currentZone != afterZone)
                {
                    currentZone.Monsters.Remove(monster);
                    afterZone.Monsters.Add(monster);
                }
            }

            transform.Position.X = dest.x;
            transform.Position.Z = dest.y;
            return true;
        }

        /// <summary>
        /// Map 불러오는 함수
        /// </summary>
        /// <param name="mapId">불러올 Map ID</param>
        /// <param name="pathPrefix">MapData 폴더 경로</param>
        public void LoadMap(int mapId, string pathPrefix = "../../../../../Common/MapData")
        {
            string mapName = "Map_" + mapId.ToString("000");
            string text = File.ReadAllText($"{pathPrefix}/{mapName}.txt");
            var reader = new StringReader(text);

            MinX = int.Parse(reader.ReadLine());
            MaxX = int.Parse(reader.ReadLine());
            MinY = int.Parse(reader.ReadLine());
            MaxY = int.Parse(reader.ReadLine());

            int xCount = MaxX - MinX + 1;
            int yCount = MaxY - MinY + 1;
            _collision = new bool[yCount, xCount];
            _objects = new GameObject[yCount, xCount];

            for (int y = 0; y < yCount; y++)
            {
                string line = reader.ReadLine();
                for (int x = 0; x < xCount; x++)
                {
                    _collision[y, x] = line[x] == '1';
                }
            }
        }

        #region A* Path Finding
        private int[] _deltaY = new int[] { 1, -1, 0, 0 };
        private int[] _deltaX = new int[] { 0, 0, -1, 1 };
        private int[] _cost = new int[] { 10, 10, 10, 10 };

        /// <summary>
        /// A* 알고리즘으로 길을 찾는 함수
        /// </summary>
        /// <param name="startCellPos">시작 위치</param>
        /// <param name="destCellPos">목적지 위치</param>
        /// <param name="checkObjects">오브젝트(장애물) 확인 여부</param>
        /// <param name="maxDist">탐색 최대 거리</param>
        /// <returns>최단 경로 Vector2Int 리스트</returns>
        public List<Vector2Int> FindPath(Vector2Int startCellPos, Vector2Int destCellPos, bool checkObjects = true, int maxDist = 10)
        {
            // F = G + H
            // F = 최종 점수 (작을 수록 좋음, 경로에 따라 달라짐)
            // G = 시작점에서 해당 좌표까지 이동하는데 드는 비용 (작을 수록 좋음, 경로에 따라 달라짐)
            // H = 목적지에서 얼마나 가까운지 (작을 수록 좋음, 고정)

            // (y, x) 이미 방문했는지 여부 (방문 = closed 상태)
            var closeList = new HashSet<Pos>(); // CloseList

            // (y, x) 가는 길을 한 번이라도 발견했는지
            // 발견X => MaxValue
            // 발견O => F = G + H
            var openList = new Dictionary<Pos, int>(); // OpenList
            var parent = new Dictionary<Pos, Pos>();

            // 오픈리스트에 있는 정보들 중에서, 가장 좋은 후보를 빠르게 뽑아오기 위한 도구
            var pq = new PriorityQueue<PQNode>();

            // CellPos -> ArrayPos
            var pos = Cell2Pos(startCellPos);
            var dest = Cell2Pos(destCellPos);

            // 시작점 발견 (예약 진행)
            openList.Add(pos, 10 * (Math.Abs(dest.Y - pos.Y) + Math.Abs(dest.X - pos.X)));

            pq.Push(new PQNode() { F = 10 * (Math.Abs(dest.Y - pos.Y) + Math.Abs(dest.X - pos.X)), G = 0, Y = pos.Y, X = pos.X });
            parent.Add(pos, pos);

            while (pq.Count > 0)
            {
                // 제일 좋은 후보를 찾는다
                var pqNode = pq.Pop();
                var node = new Pos(pqNode.Y, pqNode.X);

                // 동일한 좌표를 여러 경로로 찾아서, 더 빠른 경로로 인해서 이미 방문(closed)된 경우 스킵
                if (closeList.Contains(node))
                    continue;

                // 방문한다
                closeList.Add(node);

                // 목적지 도착했으면 바로 종료
                if (node.Y == dest.Y && node.X == dest.X)
                    break;

                // 상하좌우 등 이동할 수 있는 좌표인지 확인해서 예약(open)한다
                for (int i = 0; i < _deltaY.Length; i++)
                {
                    var next = new Pos(node.Y + _deltaY[i], node.X + _deltaX[i]);

                    // 너무 멀면 스킵
                    if (Math.Abs(pos.Y - next.Y) + Math.Abs(pos.X - next.X) > maxDist)
                        continue;

                    // 유효 범위를 벗어났으면 스킵
                    // 벽으로 막혀서 갈 수 없으면 스킵
                    if (next.Y != dest.Y || next.X != dest.X)
                    {
                        if (CanGo(Pos2Cell(next), checkObjects) == false) // CellPos
                            continue;
                    }

                    // 이미 방문한 곳이면 스킵
                    if (closeList.Contains(next))
                        continue;

                    // 비용 계산
                    int g = 0;// node.G + _cost[i];
                    int h = 10 * ((dest.Y - next.Y) * (dest.Y - next.Y) + (dest.X - next.X) * (dest.X - next.X));
                    
                    // 다른 경로에서 더 빠른 길 이미 찾았으면 스킵
                    if (openList.TryGetValue(next, out int value) == false)
                        value = int.MaxValue;

                    if (value < g + h)
                        continue;

                    // 예약 진행
                    if (openList.TryAdd(next, g + h) == false)
                        openList[next] = g + h;

                    pq.Push(new PQNode() { F = g + h, G = g, Y = next.Y, X = next.X });

                    if (parent.TryAdd(next, node) == false)
                        parent[next] = node;
                }
            }

            return CalcCellPathFromParent(parent, dest);
        }

        private List<Vector2Int> CalcCellPathFromParent(Dictionary<Pos, Pos> parent, Pos dest)
        {
            var cells = new List<Vector2Int>();

            if (parent.ContainsKey(dest) == false)
            {
                var best = new Pos();
                int bestDist = int.MaxValue;

                foreach (var pos in parent.Keys)
                {
                    int dist = Math.Abs(dest.X - pos.X) + Math.Abs(dest.Y - pos.Y);

                    // 제일 우수한 후보를 뽑는다
                    if (dist < bestDist)
                    {
                        best = pos;
                        bestDist = dist;
                    }
                }

                dest = best;
            }

            {
                var pos = dest;
                while (parent[pos] != pos)
                {
                    cells.Add(Pos2Cell(pos));
                    pos = parent[pos];
                }
                cells.Add(Pos2Cell(pos));
                cells.Reverse();
            }

            return cells;
        }

        private Pos Cell2Pos(Vector2Int cell) => new Pos(MaxY - cell.y, cell.x - MinX);
        private Vector2Int Pos2Cell(Pos pos) => new Vector2Int(pos.X + MinX, MaxY - pos.Y);
        #endregion
    }
}