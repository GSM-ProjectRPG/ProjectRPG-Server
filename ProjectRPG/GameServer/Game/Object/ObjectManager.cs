using Google.Protobuf.Protocol;

namespace GameServer.Game
{
    public class ObjectManager
    {
        public static ObjectManager Instance { get; } = new ObjectManager();

        private readonly object _lock = new object();
        private int _count = 0;

        public T Add<T>() where T : GameObject, new()
        {
            var gameObject = new T();

            lock (_lock)
            {
                gameObject.Id = GenerateId(gameObject.Type);
            }

            return gameObject;
        }

        private int GenerateId(GameObjectType type)
        {
            lock (_lock)
            {
                return ((int)type << 24) | (_count++);
            }
        }

        public static GameObjectType GetObjectTypeById(int id)
        {
            int type = (id >> 24) & 0x7F;
            return (GameObjectType)type;
        }
    }
}