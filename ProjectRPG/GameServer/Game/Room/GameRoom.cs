using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Job;

namespace ProjectRPG.Game
{
    public partial class GameRoom : JobSerializer
    {
        public int RoomId { get; set; }

        public void Update()
        {
            Flush();
        }
    }
}