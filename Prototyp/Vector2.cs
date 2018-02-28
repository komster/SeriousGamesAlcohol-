using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyp
{
    public struct Vector2
    {
        public double X;
        public double Y;

        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;

        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, float m)
        {
            return new Vector2(v1.X * m, v1.Y * m);
        }

        public static double operator *(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        public static Vector2 operator /(Vector2 v1, float m)
        {
            return new Vector2(v1.X / m, v1.Y / m);
        }

        public static Vector2 rotateVector(Vector2 v1, float angle)
        {
            return new Vector2(v1.X * Math.Cos(angle) - v1.X * Math.Sin(angle), v1.Y * Math.Cos(angle) + v1.Y * Math.Sin(angle));
        }

    }
}
