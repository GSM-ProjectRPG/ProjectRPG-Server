using System;
using System.Linq;
using System.Collections.Generic;
using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class VisionField
    {
        public Player Owner { get; private set; }
        public HashSet<GameObject> PreviousObjects { get; private set; } = new HashSet<GameObject>();

        public VisionField(Player owner)
        {
            Owner = owner;
        }

        public void Update()
        {
            if (Owner == null || Owner.CurrentRoom == null)
                return;

            var currentObjects = GatherObjects();

            // 범위 안에 추가된 오브젝트들을 Spawn
            var added = currentObjects.Except(PreviousObjects).ToList();
            if (added.Count > 0)
            {
                var spawnPacket = new S_Spawn();

                foreach (var gameObject in added)
                {
                    var info = new GameObjectInfo();
                    info.MergeFrom(gameObject.Info);
                    spawnPacket.Objects.Add(info);
                }

                Owner.Session.Send(spawnPacket);
            }

            // 범위 밖으로 나간 오브젝트들을 Despawn
            var removed = PreviousObjects.Except(currentObjects).ToList();
            if (removed.Count > 0)
            {
                var despawnPacket = new S_Despawn();

                foreach (var gameObject in removed)
                    despawnPacket.ObjectIds.Add(gameObject.Id);

                Owner.Session.Send(despawnPacket);
            }

            PreviousObjects = currentObjects;
            Owner.CurrentRoom.PushAfter(100, Update);
        }

        /// <summary>
        /// 플레이어의 시야 범위 안의 GameObject들을 찾아 반환하는 함수
        /// </summary>
        /// <returns></returns>
        public HashSet<GameObject> GatherObjects()
        {
            if (Owner == null || Owner.CurrentRoom == null)
                return null;

            var objects = new HashSet<GameObject>();
            var zones = Owner.CurrentRoom.GetZonesInRange(Owner.CellPos);
            var cellPos = Owner.CellPos;

            foreach (var zone in zones)
            {
                foreach (var player in zone.Players)
                {
                    int dx = player.CellPos.x - cellPos.x;
                    int dy = player.CellPos.y - cellPos.y;
                    if (Math.Abs(dx) > GameRoom.VisionCells) continue;
                    if (Math.Abs(dy) > GameRoom.VisionCells) continue;
                    objects.Add(player);
                }

                foreach (var monster in zone.Monsters)
                {
                    int dx = monster.CellPos.x - cellPos.x;
                    int dy = monster.CellPos.y - cellPos.y;
                    if (Math.Abs(dx) > GameRoom.VisionCells) continue;
                    if (Math.Abs(dy) > GameRoom.VisionCells) continue;
                    objects.Add(monster);
                }
            }

            return objects;
        }
    }
}