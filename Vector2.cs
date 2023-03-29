using System;

namespace GravityBalls
{
    public struct Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Length => Math.Sqrt(X * X + Y * Y);

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2(double firstX, double firstY, double secondX, double secondY) : this(secondX - firstX, secondY - firstY) {}

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator *(double alpha, Vector2 a)
        {
            return new Vector2(a.X * alpha, a.Y * alpha);
        }

        public static Vector2 operator *(Vector2 a, double alpha) => alpha * a;


    }
}
