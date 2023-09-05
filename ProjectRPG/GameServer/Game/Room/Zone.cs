using System;
using System.Collections.Generic;
using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class Zone
    {
        public int IndexY { get; set; }
        public int IndexX { get; set; }

        public Zone(int y, int x)
        {
            IndexY = y;
            IndexX = x;
        }

        public HashSet<Player> Players { get; set; } = new HashSet<Player>();
        public HashSet<Monster> Monsters { get; set; } = new HashSet<Monster>();

        public void Remove(GameObject gameObject)
        {
            var type = ObjectManager.GetObjectTypeById(gameObject.Id);

            switch (type)
            {
                case GameObjectType.Player:
                    Players.Remove((Player)gameObject);
                    break;
                case GameObjectType.Monster:
                    Monsters.Remove((Monster)gameObject);
                    break;
            }
        }

        public Player FindOnePlayer(Func<Player, bool> predicate)
        {
            foreach (var player in Players)
            {
                if (predicate.Invoke(player))
                    return player;
            }

            return null;
        }

        public List<Player> FindAllPlayer(Func<Player, bool> predicate)
        {
            var findList = new List<Player>();

            foreach (var player in Players)
            {
                if (predicate.Invoke(player))
                    findList.Add(player);
            }

            return findList;
        }
    }
}