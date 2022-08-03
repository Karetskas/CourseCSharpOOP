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
            return Radius + Radius;
        }

        public double GetHeight()
        {
            return Radius + Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Circle: radius = {Radius}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
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

            return prime * hash + Radius.GetHashCode();
        }
    }
}
