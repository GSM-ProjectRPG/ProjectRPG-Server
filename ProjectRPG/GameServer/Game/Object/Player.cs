using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class Player : GameObject
    {
        public int PlayerDbId { get; set; }
        public ClientSession Session { get; set; }
        public VisionField Vision { get; private set; }

        public Inventory Inven { get; set; }

        public Player()
        {
            Type = GameObjectType.Player;
            Vision = new VisionField(this);
        }

        public override void OnDead(GameObject killer)
        {
            base.OnDead(killer);
        }
    }
}