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

            Speed = 1f;
        }

        public void Move()
        {
            Transform.Position.X += Speed * InputVector.X * 0.02f;
            Transform.Position.Z += Speed * InputVector.Z * 0.02f;

            var movePacket = new S_Move()
            {
                ObjectId = Id,
                Position = Transform.Position
            };
            CurrentRoom.Broadcast(CellPos, movePacket);
            Console.WriteLine($"{movePacket.Position.X} {movePacket.Position.Z}");
            if (InputVector.X != 0 || InputVector.Z != 0)
                CurrentRoom.PushAfter(25, Move);
        }

        public override void OnDead(GameObject killer)
        {
            base.OnDead(killer);
        }
    }
}