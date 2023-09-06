using System;

namespace ProjectRPG.Game
{
    public struct PQNode : IComparable<PQNode>
    {
        public int F;
        public int G;
        public int Y;
        public int X;

        public int CompareTo(PQNode other)
        {
            if (F == other.F)
                return 0;

            return F < other.F ? 1 : -1;
        }
    }
}