﻿using System;
using System.Net;
using ACore;
using ProjectRPG.Session;

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
        }
    }
}