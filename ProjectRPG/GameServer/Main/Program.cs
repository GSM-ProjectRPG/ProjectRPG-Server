using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Program
    {
        private static void Main()
        {
            ServerService server = new ServerService();

            server.Start();

            while (true)
            {

            }
        }
    }
}