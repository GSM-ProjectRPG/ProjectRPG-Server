using System;
using GameServer.Data;
using Google.Protobuf.Protocol;

namespace GameServer.Game
{
    public class ObjectSpawner
    {
        private static Random _rand = new Random();

        public static void Spawn(GameObject go)
        {
            if (go == null) return;

            var type = ObjectManager.GetObjectTypeById(go.Id);
            if (type == GameObjectType.Player)
            {
                DataManager.SpawnDict.TryGetValue(0, out var spawnData);
                go.Transform.Position = GetRandomPosInArea(spawnData);
            }
            else if (type == GameObjectType.Monster)
            {
                var monster = (Monster)go;
                DataManager.MonsterDict.TryGetValue(monster.TemplateId, out var monsterData);
                DataManager.SpawnDict.TryGetValue(monsterData.stat.Level, out var spawnData);
                go.Transform.Position = GetRandomPosInArea(spawnData);
            }
        }

        public static Vector GetRandomPosInArea(SpawnData spawnData)
        {
            int range = spawnData.range;
            var pos = new Vector()
            {
                X = spawnData.pos.X + _rand.Next(-range, range),
                Y = spawnData.pos.Y,
                Z = spawnData.pos.Z + _rand.Next(-range, range)
            };
            return pos;
        }
    }
}