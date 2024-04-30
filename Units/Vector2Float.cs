using SFML.System;

namespace GeneratedGame.Units
{
    internal class Vector2Float
    {
        public static readonly Vector2Float ZERO = new Vector2Float(0, 0);
        public static readonly Vector2Float UP = new Vector2Float(0, 1);
        public static readonly Vector2Float DOWN = new Vector2Float(0, -1);
        public static readonly Vector2Float LEFT = new Vector2Float(-1, 0);
        public static readonly Vector2Float RIGHT = new Vector2Float(1, 0);

        public float X { get; set; }
        public float Y { get; set; }

        public Vector2Float(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2Float(float val) : this(val, val) {}

        public Vector2Float(Vector2Float copy) : this(copy.X, copy.Y) { }

        public Vector2Float(Vector2f sfmlVec) : this(sfmlVec.X, sfmlVec.Y) { }

        public static Vector2Float operator *(Vector2Float a, Vector2Float b) => new Vector2Float(a.X * b.X, a.Y * b.Y);
        public static Vector2Float operator *(Vector2Float a, float b) => new Vector2Float(a.X * b, a.Y * b);

        public static Vector2Float operator +(Vector2Float a, Vector2Float b) => new Vector2Float(a.X + b.X, a.Y + b.Y);

        public static Vector2Float operator -(Vector2Float a, Vector2Float b) => new Vector2Float(a.X - b.X, a.Y - b.Y);

        public static Vector2Float operator /(Vector2Float a, Vector2Float b) => new Vector2Float(a.X / b.X, a.Y / b.Y);
        public static Vector2Float operator /(Vector2Float a, float b) => new Vector2Float(a.X / b, a.Y / b);
        public static Vector2Float operator /(float a, Vector2Float b) => new Vector2Float(a / b.X, a / b.Y);
    }
}
