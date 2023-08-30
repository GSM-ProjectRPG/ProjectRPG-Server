using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class EntityManager
    {
        public static EntityManager Instance { get; } = new EntityManager();

        private readonly object _lock = new object();
        private int _count = 0;

        public T Add<T>() where T : Entity, new()
        {
            var entity = new T();

            lock (_lock)
            {
                entity.Id = GenerateId(entity.Type);
            }

            return entity;
        }

        private int GenerateId(EntityType type)
        {
            lock (_lock)
            {
                return ((int)type << 24) | (_count++);
            }
        }

        public static EntityType GetEntityTypeById(int id)
        {
            int type = (id >> 24) & 0x7F;
            return (EntityType)type;
        }
    }
}