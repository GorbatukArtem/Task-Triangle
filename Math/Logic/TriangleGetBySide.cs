using System;
using System.Drawing;
using Math.Types;

namespace Math.Logic
{
    public class TriangleGetBySide : ITriangleGetKindOf
    {
        public TriangleBySidesType GetKindOf(Point a, Point b, Point c)
        {
            // в письме в примечании ошибка )) по началу не проходили тесты, ниже правильный расчет, на основе формул с картинки
            // https://cf2.ppt-online.org/files2/slide/q/qLU2k0TWRE6a3A1yDeiuGwFZgcdjB7IPK5nOXQ/slide-20.jpg
            // прямоугольный (Right) a^2 = b^2 + c^2
            // тупоугольный (Obtuse) a^2 > b^2 + c^2
            // остроугольный (Acute) a^2 < b^2 + c^2

            var sideA = CalculateSide(b, c);
            var sideB = CalculateSide(a, c);
            var sideC = CalculateSide(a, b);

            if ((sideA + sideB).Equals(sideC) || 
                (sideA + sideC).Equals(sideB) || 
                (sideC + sideB).Equals(sideA))
            {
                return TriangleBySidesType.Right;
            }

            if (sideA + sideB < sideC || 
                sideA + sideC < sideB || 
                sideC + sideB < sideA)
            {
                return TriangleBySidesType.Obtuse;
            }

            if (sideA + sideB > sideC ||
                sideA + sideC > sideB ||
                sideC + sideB > sideA)
            {
                return TriangleBySidesType.Acute;
            }

            throw new ArgumentOutOfRangeException($"TriangleGetBySide, calculation is not working as expected.");
        }

        private double CalculateSide(Point p1, Point p2)
        {
            var a = System.Math.Abs(p2.X - p1.X);
            var b = System.Math.Abs(p2.Y - p1.Y);
            return System.Math.Pow(a, 2) + System.Math.Pow(b, 2);

            // реальный размер от точки до точки необходимо вычислить корень, 
            // отказался, причина - затем несколько раз этот результат возводиться назад во 2ю степень.
            //return System.Math.Sqrt(System.Math.Pow(a, 2) + System.Math.Pow(b, 2));
        }
    }
}