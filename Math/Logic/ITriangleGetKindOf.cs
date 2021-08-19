using System.Drawing;
using Math.Types;

namespace Math.Logic
{
    public interface ITriangleGetKindOf
    {
        TriangleBySidesType GetKindOf(Point a, Point b, Point c);
    }
}