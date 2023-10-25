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
        }
        
        public void HandleChat(Player player, C_Chat chatPacket)
        {
            S_Chat recvdChat = new S_Chat
            {
                ObjectId = player.Id,
                Content = chatPacket.Content
            };
            Broadcast(player.CellPos, recvdChat);
        }
    }
}