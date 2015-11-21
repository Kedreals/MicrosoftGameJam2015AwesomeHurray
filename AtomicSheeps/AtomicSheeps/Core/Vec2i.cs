using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Core
{
    /// <summary>
    /// 2d vector using int values
    /// </summary>
    struct Vec2i
    {
        public int X;
        public int Y;

        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }

        public Vec2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        //Casts************************************************************************

        public static implicit operator Vector2i(Vec2i v)
        {
            return new Vector2i(v.X, v.Y);
        }

        public static implicit operator Vec2i(Vector2i v)
        {
            return new Vec2i(v.X, v.Y);
        }

        public static implicit operator Vec2f(Vec2i v)
        {
            return new Vec2f(v.X, v.Y);
        }

        //operators********************************************************************

        public static bool operator ==(Vec2i a, Vec2i b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vec2i a, Vec2i b)
        {
            return !(a.X == b.X && a.Y == b.Y);
        }

        public static Vec2i operator +(Vec2i a, Vec2i b)
        {
            return new Vec2i(a.X + b.X, a.Y + b.Y);
        }

        public static Vec2i operator -(Vec2i a, Vec2i b)
        {
            return new Vec2i(a.X - b.X, a.Y - b.Y);
        }

        public static Vec2i operator *(Vec2i v, int f)
        {
            return new Vec2i(v.X * f, v.Y * f);
        }

        public static Vec2i operator *(int f, Vec2i v)
        {
            return new Vec2i(v.X * f, v.Y * f);
        }

        public static Vec2i operator /(Vec2i v, int f)
        {
            return new Vec2i(v.X / f, v.Y / f);
        }

        /// <summary>
        /// modulo on each component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Vec2i operator %(Vec2i v, int i)
        {
            return new Vec2i(v.X % i, v.Y % i);
        }

        /// <summary>
        /// modulo component wise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec2i operator %(Vec2i a, Vec2i b)
        {
            return new Vec2i(a.X % b.X, a.Y % b.Y);
        }

        public static Vec2i operator -(Vec2i v)
        {
            return new Vec2i(-v.X, -v.Y);
        }

        //other************************************************************************

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// create a valid String
        /// </summary>
        /// <returns>vector as String</returns>
        public override string ToString()
        {
            return "[" + X + ", " + Y + " ]";
        }
    }
}
