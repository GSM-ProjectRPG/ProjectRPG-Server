﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public class Program
    {
        private static void Main()
        {
            var server = new ServerService();
            server.Start();

            while (true)
            {

            }
        }
    }
}