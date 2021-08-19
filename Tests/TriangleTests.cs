using System;
using System.Collections.Generic;
using System.Drawing;
using Math;
using Math.Logic;
using Math.Types;
using NUnit.Framework;

namespace Tests
{
    public class TriangleTests
    {
        [TestCaseSource(nameof(ThreePontsOnOneLineTestCases))]
        public void CtorThrow_ThreePontsOnOneLine_Test(string testNumber, Point a, Point b, Point c, string expected)
        {
            var exception = Assert.Throws<Exception>(() => new Triangle(a, b, c));

            Assert.That(exception?.Message, Is.EqualTo(expected), testNumber);
        }

        [TestCaseSource(nameof(TriangleTestCases))]
        public void GetKindOf_StrategySide_Test(string testNumber, Point a, Point b, Point c, TriangleBySidesType expected)
        {
            var triangle = new Triangle(a, b, c);

            var actual = triangle.GetKindOf(new TriangleGetBySide());

            Assert.AreEqual(expected, actual, testNumber);
        }

        [TestCaseSource(nameof(TriangleTestCases))]
        public void GetKindOf_StrategyAngle_Test(string testNumber, Point a, Point b, Point c, TriangleBySidesType expected)
        {
            var triangle = new Triangle(a, b, c);

            var actual = triangle.GetKindOf(new TriangleGetByAngle());
            
            Assert.AreEqual(expected, actual, testNumber);
        }

        private static IEnumerable<object[]> ThreePontsOnOneLineTestCases()
        {
            yield return new object[] { "Test Case 01", new Point(1, 1), new Point(1, 1), new Point(1, 1), "All points on one line" };
            yield return new object[] { "Test Case 02", new Point(-2, 1), new Point(0, 1), new Point(2, 1), "All points on one line" };
            yield return new object[] { "Test Case 03", new Point(-2, -2), new Point(0, 0), new Point(2, 2), "All points on one line" };
            yield return new object[] { "Test Case 04", new Point(-2, -1), new Point(0, 0), new Point(2, 1), "All points on one line" };
            yield return new object[] { "Test Case 05", new Point(-2, -2), new Point(0, -1), new Point(4, 1), "All points on one line" };
        }
        private static IEnumerable<object[]> TriangleTestCases()
        {
            yield return new object[] { "Test Case Triangle Right 01", new Point(1, 1), new Point(1, 3), new Point(3, 1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 02", new Point(1, 1), new Point(3, 3), new Point(3, 1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 03", new Point(1, 1), new Point(1, 3), new Point(3, 3), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 04", new Point(1, 3), new Point(3, 3), new Point(3, 1), TriangleBySidesType.Right };

            yield return new object[] { "Test Case Triangle Right 05", new Point(1, -1), new Point(1, -3), new Point(3, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 06", new Point(1, -1), new Point(3, -3), new Point(3, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 07", new Point(1, -1), new Point(1, -3), new Point(3, -3), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 08", new Point(1, -3), new Point(3, -3), new Point(3, -1), TriangleBySidesType.Right };

            yield return new object[] { "Test Case Triangle Right 09", new Point(-1, -1), new Point(-1, -3), new Point(-3, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 10", new Point(-1, -1), new Point(-3, -3), new Point(-3, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 11", new Point(-1, -1), new Point(-1, -3), new Point(-3, -3), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 12", new Point(-1, -3), new Point(-3, -3), new Point(-3, -1), TriangleBySidesType.Right };

            yield return new object[] { "Test Case Triangle Right 13", new Point(-1, 1), new Point(-1, 3), new Point(-3, 1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 14", new Point(-1, 1), new Point(-3, 3), new Point(-3, 1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 15", new Point(-1, 1), new Point(-1, 3), new Point(-3, 3), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 16", new Point(-1, 3), new Point(-3, 3), new Point(-3, 1), TriangleBySidesType.Right };
            
            yield return new object[] { "Test Case Triangle Right 17", new Point(-1, -1), new Point(-1, 1), new Point(1, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 18", new Point(-1, -1), new Point(1, 1), new Point(1, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 19", new Point(1, -1), new Point(1, 1), new Point(-1, 1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 20", new Point(-1, -1), new Point(-1, 1), new Point(1, 1), TriangleBySidesType.Right };

            yield return new object[] { "Test Case Triangle Right 21", new Point(1, 0), new Point(1, 2), new Point(3, 0), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 22", new Point(1, -1), new Point(1, 1), new Point(3, -1), TriangleBySidesType.Right };
            yield return new object[] { "Test Case Triangle Right 23", new Point(0, 0), new Point(0, 2), new Point(2, 0), TriangleBySidesType.Right };


            yield return new object[] { "Test Case Triangle Obtuse 01", new Point(1, 1), new Point(0, 3), new Point(3, 1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 02", new Point(1, 1), new Point(4, 3), new Point(3, 1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 03", new Point(1, 1), new Point(1, 3), new Point(3, 4), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 04", new Point(1, 3), new Point(3, 3), new Point(4, 1), TriangleBySidesType.Obtuse };

            yield return new object[] { "Test Case Triangle Obtuse 05", new Point(1, -1), new Point(0, -3), new Point(3, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 06", new Point(1, -1), new Point(4, -3), new Point(3, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 07", new Point(1, -1), new Point(1, -3), new Point(3, -4), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 08", new Point(1, -3), new Point(3, -3), new Point(4, -1), TriangleBySidesType.Obtuse };

            yield return new object[] { "Test Case Triangle Obtuse 09", new Point(-1, -1), new Point(0, -3), new Point(-3, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 10", new Point(-1, -1), new Point(-4, -3), new Point(-3, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 11", new Point(-1, -1), new Point(-1, -3), new Point(-3, -4), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 12", new Point(-1, -3), new Point(-3, -3), new Point(-4, -1), TriangleBySidesType.Obtuse };

            yield return new object[] { "Test Case Triangle Obtuse 13", new Point(-1, 1), new Point(-0, 3), new Point(-3, 1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 14", new Point(-1, 1), new Point(-4, 3), new Point(-3, 1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 15", new Point(-1, 1), new Point(-1, 3), new Point(-3, 4), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 16", new Point(-1, 3), new Point(-3, 3), new Point(-4, 1), TriangleBySidesType.Obtuse };

            yield return new object[] { "Test Case Triangle Obtuse 17", new Point(-1, -1), new Point(-2, 1), new Point(1, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 18", new Point(-1, -1), new Point(2, 1), new Point(1, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 19", new Point(1, -1), new Point(1, 1), new Point(-1, 2), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 20", new Point(-1, -1), new Point(-1, 1), new Point(1, 2), TriangleBySidesType.Obtuse };

            yield return new object[] { "Test Case Triangle Obtuse 21", new Point(1, 0), new Point(0, 2), new Point(3, 0), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 22", new Point(1, -1), new Point(0, 1), new Point(3, -1), TriangleBySidesType.Obtuse };
            yield return new object[] { "Test Case Triangle Obtuse 23", new Point(0, 0), new Point(-1, 2), new Point(2, 0), TriangleBySidesType.Obtuse };
            

            yield return new object[] { "Test Case Triangle Acute 01", new Point(1, 1), new Point(2, 3), new Point(3, 1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 02", new Point(1, 1), new Point(2, 3), new Point(3, 1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 03", new Point(1, 1), new Point(1, 3), new Point(3, 2), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 04", new Point(1, 3), new Point(3, 3), new Point(2, 1), TriangleBySidesType.Acute };

            yield return new object[] { "Test Case Triangle Acute 05", new Point(1, -1), new Point(2, -3), new Point(3, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 06", new Point(1, -1), new Point(2, -3), new Point(3, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 07", new Point(1, -1), new Point(1, -3), new Point(3, -2), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 08", new Point(1, -3), new Point(3, -3), new Point(2, -1), TriangleBySidesType.Acute };

            yield return new object[] { "Test Case Triangle Acute 09", new Point(-1, -1), new Point(-2, -3), new Point(-3, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 10", new Point(-1, -1), new Point(-2, -3), new Point(-3, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 11", new Point(-1, -1), new Point(-1, -3), new Point(-3, -2), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 12", new Point(-1, -3), new Point(-3, -3), new Point(-2, -1), TriangleBySidesType.Acute };

            yield return new object[] { "Test Case Triangle Acute 13", new Point(-1, 1), new Point(-2, 3), new Point(-3, 1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 14", new Point(-1, 1), new Point(-2, 3), new Point(-3, 1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 15", new Point(-1, 1), new Point(-1, 3), new Point(-3, 2), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 16", new Point(-1, 3), new Point(-3, 3), new Point(-2, 1), TriangleBySidesType.Acute };

            yield return new object[] { "Test Case Triangle Acute 17", new Point(-1, -1), new Point(0, 1), new Point(1, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 18", new Point(-1, -1), new Point(0, 1), new Point(1, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 19", new Point(1, -1), new Point(1, 1), new Point(-1, 0), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 20", new Point(-1, -1), new Point(-1, 1), new Point(1, 0), TriangleBySidesType.Acute };

            yield return new object[] { "Test Case Triangle Acute 21", new Point(1, 0), new Point(2, 2), new Point(3, 0), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 22", new Point(1, -1), new Point(2, 1), new Point(3, -1), TriangleBySidesType.Acute };
            yield return new object[] { "Test Case Triangle Acute 23", new Point(0, 0), new Point(1, 2), new Point(2, 0), TriangleBySidesType.Acute };

        }
    }
}