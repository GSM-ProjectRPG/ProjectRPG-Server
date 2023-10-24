using System;
using Google.Protobuf.Protocol;

namespace GameServer.Game
{
    public class Player : GameObject
    {
        public int PlayerDbId { get; set; }
        public ClientSession Session { get; set; }
        public VisionField Vision { get; private set; }

        public Inventory Inven { get; set; }

        public Vector InputVector { get; set; } = new Vector();

        public Player()
        {
            Type = GameObjectType.Player;
            Vision = new VisionField(this);

            Speed = 2f;
        }

        public override void Update()
        {
            Move();

            CurrentRoom.PushAfter(200, Update);
        }

        public void Move()
        {
            if (InputVector.X == 0 && InputVector.Z == 0)
                return;

            Transform.Position.X += Speed * InputVector.X * 0.05f;
            Transform.Position.Z += Speed * InputVector.Z * 0.05f;

            var movePacket = new S_Move()
            {
                ObjectId = Id,
                Position = Transform.Position
            };
            CurrentRoom.Broadcast(CellPos, movePacket);
            Console.WriteLine($"{movePacket.Position.X} {movePacket.Position.Z}");
        }

        public override void OnDead(GameObject killer)
        {
            base.OnDead(killer);
        }
    }
}