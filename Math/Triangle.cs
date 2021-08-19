using System;
using System.Drawing;
using Math.Logic;
using Math.Types;

namespace Math
{
    /// <summary>
    /// A triangle has three sides, three vertices, and three angels.
    /// The sum of the three interior angles of a triangle is always 180°.
    /// The sum of the length of two sides of a triangle is always greater than the length of the third side.
    /// A triangle with vertices A, B, and C is denoted as △ABC.
    /// The area of a triangle is equal to half of the product of its base and height.
    /// </summary>
    public class Triangle
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }

        public Triangle(Point a, Point b, Point c)
        {
            if (a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - b.X * a.Y - a.X * c.Y == 0)
                throw new Exception("All points on one line");

            A = a;
            B = b;
            C = c;
        }

        public TriangleBySidesType GetKindOf(ITriangleGetKindOf triangle)
        {
            return triangle.GetKindOf(A,B,C);
        }
    }
}