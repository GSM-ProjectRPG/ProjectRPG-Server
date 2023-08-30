using System;
using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class Entity
    {
        public EntityInfo Info { get; set; } = new EntityInfo();
        public int Id { get => Info.Id; set => Info.Id = value; }

        public EntityType Type { get; protected set; } = EntityType.None;
        public TransformInfo Transform { get; private set; } = new TransformInfo();
        public StatInfo Stat { get; private set; } = new StatInfo();

        public GameRoom CurrentRoom { get; set; }

        public int Hp
        {
            get => Stat.Hp;
            set => Stat.Hp = value;
        }

        public float Speed
        {
            get => Stat.Speed;
            set => Stat.Speed = value;
        }

        public EntityState State
        {
            get => Transform.State;
            set => Transform.State = value;
        }

        public Entity()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnDead(Entity killer)
        {
            if (CurrentRoom == null) return;

            // TODO
        }

        public virtual Entity GetBase() => this;
    }
}