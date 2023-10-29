using Microsoft.EntityFrameworkCore;
using Google.Protobuf.Protocol;
using GameServer.Data;
using GameServer.Game;

namespace GameServer.DB
{
    public partial class DbTransaction
    {
        public static DbTransaction Instance { get; } = new DbTransaction();

        public static void RewardPlayer(Player player, RewardData rewardData, GameRoom room)
        {

        }
    }
}