using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Data;

namespace ProjectRPG
{
    public class Program
    {
        private static void Main()
        {
            ConfigManager.LoadConfig();
            DataManager.LoadData();

            var server = new ServerService();
            server.Start();

            while (true)
            {

            }
        }
    }
}