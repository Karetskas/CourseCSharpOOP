using System;

namespace Academits.Karetskas.ShapesTask
{
    public sealed class Circle : IShape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius < 0 ? 0 : radius;
        }

        public double GetWidth()
        {
            return Math.Pow(radius, 2);
        }

        public double GetHeight()
        {
            return Math.Pow(radius, 2);
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
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

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            return radius == circle.radius;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            return prime * hash + radius.GetHashCode();
        }
    }
}
