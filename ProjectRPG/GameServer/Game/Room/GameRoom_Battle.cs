using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string msg = chatPacket.Content;

            string commend = "";
            int i = 0;
            if (msg[0] == '/')
            {
                for (i = 1; i < msg.Length; ++i)
                {
                    if (msg[i] == ' ')
                    {
                        break;
                    }
                    commend += msg[i];
                }
            }
            ExecuteChat(player, commend, msg.Substring(i+1));
        }
        
        private void ExecuteChat(Player player, string command, string msg)
        {
            if (command == "whisper")
            {
                var s = msg.Substring(0, msg.IndexOf(' '));
                string content= msg.Substring(msg.IndexOf(' ') + 1);
                foreach (var players in _players.Values)
                {
                    if (players.Info.Name == s)
                    {
                        S_Chat schat = new S_Chat
                        {
                            ObjectId = players.Id,
                            Content = content
                        };
                        player.Session.Send(schat);
                        players.Session.Send(schat);
                    }
                }
            }
            else if(command == "")
            {
                S_Chat chat = new S_Chat
                {
                    ObjectId = player.Id,
                    Content = msg
                };
                BroadcastAll(chat);
            }
        }
    }
}