using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BinarySearchTreeLib.Tests.BinaryTreeTests;

namespace BinarySearchTreeLib.Tests
{
    public struct Point : IComparable<Point>
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Point other)
        {
            double firstLength = Math.Sqrt(x * x + y * y);
            double secondLength = Math.Sqrt(other.x * other.x + other.y * other.y);

            if (firstLength < secondLength)
            {
                return 1;
            }
            else if (firstLength == secondLength)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point firstPoint, Point secondPoint)
        {
            double firstLength = Math.Sqrt(firstPoint.x * firstPoint.x + firstPoint.y * firstPoint.y);
            double secondLength = Math.Sqrt(secondPoint.x * secondPoint.x + secondPoint.y * secondPoint.y);

            if (firstLength < secondLength)
            {
                return 1;
            }
            else if (firstLength == secondLength)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
