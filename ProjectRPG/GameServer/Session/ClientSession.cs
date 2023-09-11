using System;
using System.Collections.Generic;
using System.Net;
using ACore;
using Google.Protobuf;
using Google.Protobuf.Protocol;
using GameServer.Game;

namespace GameServer
{
    public partial class ClientSession : PacketSession
    {
        public PlayerServerState ServerState { get; private set; } = PlayerServerState.Login;

        public int SessionId { get; set; }
        public Player MyPlayer { get; set; }

        private readonly object _lock = new object();
        private List<ArraySegment<byte>> _reserveList = new List<ArraySegment<byte>>();
        private int _reservedSendBytes = 0;
        private long _lastSendTick = 0;

        #region Network Methods
        public void Send(IMessage packet)
        {
            string msgName = packet.Descriptor.Name.Replace("_", string.Empty);
            MsgId msgId = (MsgId)Enum.Parse(typeof(MsgId), msgName);
            ushort size = (ushort)packet.CalculateSize();
            byte[] sendBuffer = new byte[size + 4];
            Array.Copy(BitConverter.GetBytes((ushort)(size + 4)), 0, sendBuffer, 0, sizeof(ushort));
            Array.Copy(BitConverter.GetBytes((ushort)msgId), 0, sendBuffer, 2, sizeof(ushort));
            Array.Copy(packet.ToByteArray(), 0, sendBuffer, 4, size);

            lock (_lock) // 바로 Send 하지 않고 리스트에 추가
            {
                _reserveList.Add(sendBuffer);
                _reservedSendBytes += sendBuffer.Length;
            }
        }

        public void FlushSend()
        {
            List<ArraySegment<byte>> sendList = null;

            lock (_lock)
            {
                // 0.1s 가 지났거나, 패킷이 너무 많이 모일 때만 전송 (10000 byte 이상)
                long delta = Environment.TickCount64 - _lastSendTick;
                if (delta < 100 && _reservedSendBytes < 10000)
                    return;

                _reservedSendBytes = 0;
                _lastSendTick = Environment.TickCount64;

                sendList = _reserveList;
                _reserveList = new List<ArraySegment<byte>>();
            }

            Send(sendList);
        }

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
        #endregion
    }
}