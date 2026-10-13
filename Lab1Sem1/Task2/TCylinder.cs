using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class TCylinder : TCircle
    {
        double _height;
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)throw new ArgumentOutOfRangeException("Height can`t be negative");
                _height = value;
            }
        }
        public TCylinder()
        {
            _height = 0;
        }
        public TCylinder(double radius, double height) : base(radius)
        {
            Height = height;
        }
        public TCylinder(TCylinder other) : base(other)
        {
            _height = other._height;
        }
       
        
        public double GetVolume()
        {
            return base.GetArea() * _height;
        }
        public override double GetArea()
        {
            return base.GetArea() * 2 + GetLength() * _height;
        }
        public override string ToString()
        {
            return $"Cylinder: radius = {_radius}, height = {_height}";
        }
        public override void Output()
        {
            Console.WriteLine(this);
            Console.WriteLine($"Volume: {GetVolume():F3}");
            Console.WriteLine($"Area: {GetArea():F3}\n");
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Enter height: ");
            double height = double.Parse(Console.ReadLine());
            Height = height;
        }
        public static TCylinder operator +(TCylinder c1, TCylinder c2)
        {
            return new TCylinder(c1._radius + c2._radius, c1._height + c2._height);
        }
        public static TCylinder operator -(TCylinder c1, TCylinder c2)
        {
            return new TCylinder(c1._radius - c2._radius, c1._height - c2._height);
        }
        public static TCylinder operator *(TCylinder c, double scalar)
        {
            return new TCylinder(c._radius * scalar, c._height * scalar);
        }
        public static TCylinder operator *(double scalar, TCylinder c)
        {
            return new TCylinder(c._radius * scalar, c._height * scalar);
        }
    }
}
