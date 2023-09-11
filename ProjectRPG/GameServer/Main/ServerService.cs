using System;
using System.Linq;
using System.Net;
using System.Threading;
using ACore;
using GameServer.Game;
using SharedDB;

namespace GameServer
{
    public class ServerService
    {
        public readonly string Name;
        public readonly int Port;
        public string IpAddress;

        private readonly Listener _listener = new Listener();

        public ServerService(string name, string port)
        {
            Name = name;
            Port = int.Parse(port);
        }

        public void Start()
        {
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, Port);

            IpAddress = ipAddr.ToString();

            _listener.Init(endPoint, SessionManager.Instance.Generate);
            Console.WriteLine($"[{Name}] server is running on {IpAddress}:{Port}");

            StartServerInfoTask();

            // NetworkTask
            {
                var t = new Thread(NetworkTask) { Name = nameof(NetworkTask) };
                t.Start();
            }

            // GameLogicTask
            Thread.CurrentThread.Name = nameof(GameLogicTask);
            GameLogicTask();
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

        public void GameLogicTask()
        {
            while (true)
            {
                GameLogic.Instance.Update();
                Thread.Sleep(0);
            }
        }

        private void StartServerInfoTask()
        {
            var timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler((s, e) =>
            {
                using (var shared = new SharedDbContext())
                {
                    var serverDb = shared.Servers.Where(s => s.Name == Name).FirstOrDefault();
                    if (serverDb != null)
                    {
                        serverDb.IpAddress = IpAddress;
                        serverDb.Port = Port;
                        serverDb.BusyScore = SessionManager.Instance.GetBusyScore();
                        shared.SaveChangesEx();
                    }
                    else
                    {
                        serverDb = new ServerDb()
                        {
                            Name = this.Name,
                            IpAddress = this.IpAddress,
                            Port = this.Port,
                            BusyScore = SessionManager.Instance.GetBusyScore()
                        };
                        shared.Servers.Add(serverDb);
                        shared.SaveChangesEx();
                    }
                }
            });
            timer.Interval = 10 * 1000;
            timer.Start();
        }
    }
}