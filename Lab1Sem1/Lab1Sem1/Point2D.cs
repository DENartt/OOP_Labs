using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Sem1
{
    struct Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double DistanceTo(Point2D other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        public static double CrossProduct(Point2D a, Point2D b, Point2D c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }
    }
}
