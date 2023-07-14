using System;
using System.Net;
using ACore;

namespace ProjectRPG.Session
{
    public class ClientSession : PacketSession
    {
        public int SessionId { get; set; }

        public override void OnConnected(EndPoint endPoint)
        {

        }

        public override void OnDisconnected(EndPoint endPoint)
        {

        }

        public override void OnRecvPacket(ArraySegment<byte> buffer)
        {

        }

        public override void OnSend(int numOfBytes)
        {

        }
    }
}