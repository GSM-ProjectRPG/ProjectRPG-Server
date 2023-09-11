using GameServer.Data;

namespace GameServer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            ConfigManager.LoadConfig();
            //DataManager.LoadData();

            var server = new ServerService(args[0], args[1]);
            server.Start();

            while (true)
            {

            }
        }
    }
}