using System;

namespace Academits.Karetskas.ShapesTask.Shapes
{
    public sealed class Circle : IShape
    {
        private double radius;

        public double Radius
        {
            get => radius;

            set => radius = value < 0 ? 0 : value;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return radius + radius;
        }

        public double GetHeight()
        {
            return radius + radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return $"Circle: radius = {radius}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            return Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            return prime * hash + radius.GetHashCode();
        }
    }
}
