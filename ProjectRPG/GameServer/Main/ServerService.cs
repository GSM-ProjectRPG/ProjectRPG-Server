using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using ACore;

namespace ProjectRPG
{
    public class ServerService
    {
        private Listener _listener = new Listener();

        public void Start()
        {
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 9999);

            _listener.Init(endPoint, SessionManager.Instance.Generate);
            Console.WriteLine("서버가 실행 중입니다...");

            // NetworkTask
            {
                var t = new Thread(NetworkTask) { Name = nameof(NetworkTask) };
                t.Start();
            }
        }

        public void NetworkTask()
        {
            while (true)
            {
                var sessions = SessionManager.Instance.GetSessions();
                foreach (ClientSession session in sessions)
                    session.FlushSend();
                Thread.Sleep(0);
            }
        }
    }
}