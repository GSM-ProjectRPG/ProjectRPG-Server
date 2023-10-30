using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameServer.Job;
using Google.Protobuf;
using Google.Protobuf.Protocol;

namespace GameServer.Game
{
    public class ChatRoom : JobSerializer
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();
        
        public void Broadcast(IMessage packet)
        {
            foreach (var player in _players.Values)
            {
                player.Session.Send(packet);
            }
        }

        public void EnterChat(GameObject gameObject)
        {
            if(gameObject == null)
                return;
            
            if (ObjectManager.GetObjectTypeById(gameObject.Id) == GameObjectType.Player)
            {
                var player = (Player)gameObject;
                _players.Add(player.Id, player);
            }
        }
        
        public void LeaveChat(int gameObjectId)
        {
            var type = ObjectManager.GetObjectTypeById(gameObjectId);

            if (type == GameObjectType.Player)
            {
                if (_players.Remove(gameObjectId, out var player) == false)
                    return;
            }
            else return;
        }

        #region Packet Handling


        public void HandleChat(Player player, C_Chat chatPacket)
        {
            S_Chat recvdChat = new S_Chat
            {
                ObjectId = player.Id,
                Content = chatPacket.Content
            };
            Broadcast(recvdChat);
        }

        #endregion
    }
}
