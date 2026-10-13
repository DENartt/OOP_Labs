using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class TCircle
    {
        private protected double _radius;
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if(value < 0 ) throw new ArgumentOutOfRangeException("Radius can`t be negative");
                _radius = value;
            }
        }
        public TCircle()
        {
            _radius = 0;
        }
        public TCircle(double radius)
        {
            Radius = radius;
        }
        public TCircle(TCircle other)
        {
            if(other == null) throw new ArgumentNullException("Target object can't be null!");
            _radius = other._radius;
        }
        public override string ToString()
        {
            return $"Circle: radius = {Radius}";
        }
        public virtual double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
        public virtual double GetLength()
        {
            return 2 * Math.PI * _radius;
        }
        public int CompareTo(TCircle other)
        {
            if (other == null) return 1;

            if (_radius > other._radius) return 1;
            if (_radius < other._radius) return -1;
            return 0;
        }
        public virtual void Output()
        {
            Console.WriteLine(this);
            Console.WriteLine($"Area: {GetArea():F3}");
            Console.WriteLine($"Length: {GetLength():F3}\n");
        }
        public virtual void Input()
        {
            Console.Write("Enter radius: ");
            double radius = double.Parse(Console.ReadLine());
            Radius = radius;
        } 
        public static TCircle operator +(TCircle c1, TCircle c2)
        {
            return new TCircle(c1._radius + c2._radius);
        }
        public static TCircle operator -(TCircle c1, TCircle c2)
        {
            return new TCircle(c1._radius - c2._radius);
        }
        public static TCircle operator *(TCircle c, double scalar)
        {
            return new TCircle(c._radius * scalar);
        }
        public static TCircle operator *(double scalar, TCircle c)
        {
            return new TCircle(scalar * c._radius);
        }
    }
}
