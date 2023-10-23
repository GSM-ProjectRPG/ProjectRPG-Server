using System;
using Google.Protobuf.Protocol;
using GameServer.Job;

namespace GameServer.Game
{
    public partial class GameRoom : JobSerializer
    {
        public void HandleMove(Player player, C_Move inputPacket)
        {
            // TOOD: Collision Check

            player.InputVector = inputPacket.InputVector;
            player.Move();
        }
    }
}