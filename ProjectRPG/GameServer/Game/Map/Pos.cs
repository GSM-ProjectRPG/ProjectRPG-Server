namespace ProjectRPG.Game
{
    public struct Pos
    {
        public int Y;
        public int X;

        public Pos(int y, int x)
        {
            Y = y;
            X = x;
        }

        public static bool operator==(Pos lhs, Pos rhs) => lhs.Y == rhs.Y && lhs.X == rhs.X;
        public static bool operator!=(Pos lhs, Pos rhs) => !(lhs == rhs);

        public override bool Equals(object obj)
        {
            return (Pos)obj == this;
        }

        public override int GetHashCode()
        {
            long value = (Y << 32) | X;
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}