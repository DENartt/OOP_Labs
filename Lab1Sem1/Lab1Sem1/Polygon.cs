using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Sem1
{
    class Polygon
    {
        Point2D[] _points;
        public Polygon(Point2D[] points)
        {
            _points = points ?? new Point2D[0];

            if (!IsValid)
            {
                throw new ArgumentException("The specified points don`t form a valid polygon!");
            }
        }
        public Polygon()
        {
            _points = new Point2D[0];
        }
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= _points.Length) throw new IndexOutOfRangeException("Side index is out of range!");

                Point2D p1 = _points[i];
                Point2D p2 = _points[(i + 1) % _points.Length];

                return p1.DistanceTo(p2);
            }
        }
        public double Perimeter
        {
            get
            {
                double perimeter = 0;

                for (int i = 0; i < _points.Length; i++)
                {
                    perimeter += this[i];
                }

                return perimeter;
            }
        }
        public double Area
        {
            get
            {
                double sum = 0;

                for (int i = 0; i < _points.Length; i++)
                {
                    Point2D p1 = _points[i];
                    Point2D p2 = _points[(i + 1) % _points.Length];

                    sum += p1.X * p2.Y - p1.Y * p2.X;
                }

                return Math.Abs(sum) / 2;
            }
        }
        public bool IsValid
        {
            get
            {
                if (_points == null || _points.Length < 3)
                    return false;

                for (int i = 0; i < _points.Length; i++)
                {
                    Point2D current = _points[i];
                    Point2D next = _points[(i + 1) % _points.Length];
                    if (current.DistanceTo(next) < 1e-9) return false;
                }
                if (Math.Abs(Area) < 1e-9) return false;

                int n = _points.Length;
                for (int i = 0; i < n; i++)
                {
                    Point2D a = _points[i];
                    Point2D b = _points[(i + 1) % n];

                    for (int j = i + 2; j < n; j++)
                    {
                        if (i == 0 && j == n - 1) continue;

                        Point2D c = _points[j];
                        Point2D d = _points[(j + 1) % n];

                        if (DoIntersect(a, b, c, d)) return false;
                    }
                }
                return true;
            }
        }
        private bool DoIntersect(Point2D p1, Point2D q1, Point2D p2, Point2D q2)
        {
            double cp1 = Point2D.CrossProduct(p1, q1, p2);
            double cp2 = Point2D.CrossProduct(p1, q1, q2);
            double cp3 = Point2D.CrossProduct(p2, q2, p1);
            double cp4 = Point2D.CrossProduct(p2, q2, q1);

            if (((cp1 > 0 && cp2 < 0) || (cp1 < 0 && cp2 > 0)) && ((cp3 > 0 && cp4 < 0) || (cp3 < 0 && cp4 > 0)))
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return $"Vertices: {_points.Length}: [{string.Join(",", _points)}]";
        }
        public void Input()
        {
            Console.Write("Enter the number of vertices of the polygon:  ");
            int count = int.Parse(Console.ReadLine());
            if (count <= 2) throw new ArgumentException("The polygon must have at least three sides!");

            _points = new Point2D[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"-----{i + 1}-----");

                Console.Write("X = ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Y = ");
                double y = double.Parse(Console.ReadLine());

                _points[i] = new Point2D(x, y);
            }

            if (!IsValid) Console.WriteLine("The entered points form a non-existent polygon!");
            else Console.WriteLine("The polygon has been successfully constructed");
        }
        public void Output()
        {
            if (!IsValid) return;

            Console.WriteLine(this);
            Console.WriteLine($"Perimeter: {Perimeter:F3}");
            Console.WriteLine($"Area: {Area:F3}\n");
        }
    }
}