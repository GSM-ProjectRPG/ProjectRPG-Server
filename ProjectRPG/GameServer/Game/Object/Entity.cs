using System;
using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class Entity
    {
        public EntityInfo Info { get; set; }
        public GameRoom CurrentRoom { get; set; }
        public int Id { get => Info.Id; set => Info.Id = value; }

        public EntityType Type { get => Info.Type; protected set => Info.Type = value; }
        public TransformInfo Transform { get => Info.Transform; private set => Info.Transform = value; }

        public Entity()
        {
            Info = new EntityInfo();
            Info.Type = EntityType.None;
            Info.Transform = new TransformInfo();
        }

        public virtual void Update()
        {

        }

        public virtual void OnDead(Entity killer)
        {
            if (CurrentRoom == null) return;

            // TODO
        }
    }
}