﻿using System;

namespace ProjectRPG.Game
{
    public struct Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2Int up { get => new Vector2Int(0, 1); }
        public static Vector2Int down { get => new Vector2Int(0, -1); }
        public static Vector2Int left { get => new Vector2Int(-1, 0); }
        public static Vector2Int right { get => new Vector2Int(1, 0); }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.x - b.x, a.y - b.y);

        public int sqrMagnitude { get => x * x + y * y; }
        public float magnitude { get => (float)Math.Sqrt(sqrMagnitude); }
        public int cellDistFromZero { get => Math.Abs(x) + Math.Abs(y); }
    }
}