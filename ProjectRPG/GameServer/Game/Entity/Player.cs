using Google.Protobuf.Protocol;

namespace ProjectRPG.Game
{
    public class Player : Entity
    {
        public int PlayerDbId { get; set; }
        public ClientSession Session { get; set; }

        public Player()
        {
            Type = EntityType.Player;
        }

        public override void OnDead(Entity killer)
        {
            base.OnDead(killer);
        }
    }
}