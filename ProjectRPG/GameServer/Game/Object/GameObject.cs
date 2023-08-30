using System;
using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class GameObject
    {
        public GameObjectInfo Info { get; set; } = new GameObjectInfo();
        public int Id { get => Info.Id; set => Info.Id = value; }

        public GameObjectType Type { get; protected set; } = GameObjectType.None;
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

        public CreatureState State
        {
            get => Transform.State;
            set => Transform.State = value;
        }

        public GameObject()
        {
            Info.Type = Type;
            Info.Transform = Transform;
            Info.Stat = Stat;
        }

        public virtual void Update()
        {

        }

        public virtual void OnDead(GameObject killer)
        {
            if (CurrentRoom == null) return;

            // TODO
        }

        public virtual GameObject GetBase() => this;
    }
}