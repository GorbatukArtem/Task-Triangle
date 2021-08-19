using System.Drawing;
using Math.Types;

namespace Math.Logic
{
    public class TriangleGetByAngle : ITriangleGetKindOf
    {
        public TriangleBySidesType GetKindOf(Point a, Point b, Point c)
        {
            var angleA = CalculateAngle(a, b, c);
            var angleB = CalculateAngle(b, c, a);
            var angleC = CalculateAngle(c, a, b);

            if (angleA.Equals(90d) || angleB.Equals(90d) || angleC.Equals(90d))
            {
                return TriangleBySidesType.Right;
            }

            if (angleA > 90d || angleB > 90d || angleC > 90d)
            {
                return TriangleBySidesType.Obtuse;
            }

            return TriangleBySidesType.Acute;
        }

        private double CalculateAngle(Point topPoint, Point point1, Point point2)
        {
            var radian = System.Math.Atan2(point2.Y - topPoint.Y, point2.X - topPoint.X) - System.Math.Atan2(point1.Y - topPoint.Y, point1.X - topPoint.X);

            var degrees = radian * 180 / System.Math.PI;

            var positive = degrees < 0 ? degrees * -1 : degrees;

            var less180 = positive > 180 ? 360 - positive : positive;

            return less180;
        }


    }
}