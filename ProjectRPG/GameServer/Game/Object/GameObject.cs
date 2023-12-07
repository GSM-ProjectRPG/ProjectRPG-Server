﻿using System;
using Google.Protobuf.Protocol;

namespace GameServer.Game
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

        public Vector2Int CellPos
        {
            get => new Vector2Int((int)Transform.Position.X, (int)Transform.Position.Z);
            set
            {
                Transform.Position.X = value.x;
                Transform.Position.Z = value.y;
            }
        }

        public GameObject()
        {
            Info.Type = Type;
            Info.Transform = Transform;
            Info.Transform.Position = new Vector();
            Info.Transform.Rotation = new Vector();
            Info.Transform.Scale = new Vector() { X = 1, Y = 1, Z = 1 };
            Info.Stat = Stat;
        }

        public virtual void Update()
        {

        }

        public virtual void OnDamaged(GameObject attacker, int damage)
        {
            if (CurrentRoom == null) return;
            Hp = Math.Max(Hp - damage, 0);

            var changeHpPacket = new S_ChangeHp() { ObjectId = Id, Hp = Hp };
            CurrentRoom.Broadcast(CellPos, changeHpPacket);

            if (Hp <= 0)
                OnDead(attacker);
        }

        public virtual void OnDead(GameObject attacker)
        {
            if (CurrentRoom == null) return;

            // TODO
        }

        public virtual GameObject GetBase() => this;
    }
}