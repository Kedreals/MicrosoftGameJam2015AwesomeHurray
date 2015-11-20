using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Core
{
    /// <summary>
    /// 2d vector using float values
    /// </summary>
    struct Vec2f
    {
        public float X;
        public float Y;

        /// <summary>
        /// Length of the Vector
        /// </summary>
        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }

        public Vec2f(float x, float y)
        {
            X = x;
            Y = y;
        }


        public static Vec2f Zero { get { return new Vec2f(0, 0); } }

        //Casts************************************************************************

        public static implicit operator Vector2f(Vec2f v)
        {
            return new Vector2f(v.X, v.Y);
        }

        public static implicit operator Vec2f(Vector2f v)
        {
            return new Vec2f(v.X, v.Y);
        }

        //operator*********************************************************************

        public static bool operator ==(Vec2f a, Vec2f b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vec2f a, Vec2f b)
        {
            return !(a.X == b.X && a.Y == b.Y);
        }

        public static Vec2f operator +(Vec2f a, Vec2f b)
        {
            return new Vec2f(a.X + b.X, a.Y + b.Y);
        }

        public static Vec2f operator -(Vec2f a, Vec2f b)
        {
            return new Vec2f(a.X - b.X, a.Y - b.Y);
        }

        public static Vec2f operator *(Vec2f v, float f)
        {
            return new Vec2f(v.X * f, v.Y * f);
        }

        public static Vec2f operator *(float f, Vec2f v)
        {
            return new Vec2f(v.X * f, v.Y * f);
        }

        public static Vec2f operator /(Vec2f v, float f)
        {
            return new Vec2f(v.X / f, v.Y / f);
        }

        public static Vec2f operator /(Vec2f v1, Vec2f v2)
        {
            return new Vec2f(v1.X / v2.X, v1.Y / v2.Y);
        }

        //other************************************************************************

        /// <summary>
        /// evaluate the dot product of this and v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float Dot(Vec2f v)
        {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// evaluats the vector with the abs values of each component
        /// </summary>
        /// <returns></returns>
        public Vec2f Abs()
        {
            return new Vec2f(Math.Abs(X), Math.Abs(Y));
        }

        /// <summary>
        /// turn the direction by 180 degree
        /// </summary>
        public void Invert()
        {
            X = -X;
            Y = -Y;
        }

        /// <summary>
        /// changes the vector, so that it has the length 1
        /// </summary>
        public void Normalize()
        {
            X /= Length;
            Y /= Length;
        }

        /// <summary>
        /// returns the Vector as normalized
        /// </summary>
        /// <returns>normalized Vector</returns>
        public Vec2f GetNormalized()
        {
            return this / Length;
        }

        /// <summary>
        /// evaluate the euclidean distance between this and the given point
        /// </summary>
        /// <param name="point">position vector of a point</param>
        /// <returns>the euclidean distance between this and the point</returns>
        public float Distance(Vec2f point)
        {
            return (point - this).Length;
        }

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
