using System;
using System.Net;
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

            //_listener.Init(endPoint, SessionManager.Instance.Generate);
            Console.WriteLine("Server is running...");
        }
    }
}