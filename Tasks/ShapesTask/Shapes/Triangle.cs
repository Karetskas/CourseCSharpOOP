using System;

namespace Academits.Karetskas.ShapesTask
{
    public sealed class Triangle : IShape
    {
        private readonly double x1;
        private readonly double y1;
        private readonly double x2;
        private readonly double y2;
        private readonly double x3;
        private readonly double y3;

        private readonly double side1;
        private readonly double side2;
        private readonly double side3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;

            (double max, double min) numbersX = GetMaxAndMinNumber(x1, x2);
            (double max, double min) numbersY = GetMaxAndMinNumber(y1, y2);

            side1 = Math.Sqrt(Math.Pow(numbersX.max - numbersX.min, 2) + Math.Pow(numbersY.max - numbersY.min, 2));

            numbersX = GetMaxAndMinNumber(x2, x3);
            numbersY = GetMaxAndMinNumber(y2, y3);

            side2 = Math.Sqrt(Math.Pow(numbersX.max - numbersX.min, 2) + Math.Pow(numbersY.max - numbersY.min, 2));

            numbersX = GetMaxAndMinNumber(x1, x3);
            numbersY = GetMaxAndMinNumber(y1, y3);

            side3 = Math.Sqrt(Math.Pow(numbersX.max - numbersX.min, 2) + Math.Pow(numbersY.max - numbersY.min, 2));
        }

        private (double maxNumber, double minNumber) GetMaxAndMinNumber(double number1, double number2)
        {
            if (number1 > number2)
            {
                return (number1, number2);
            }

            return (number2, number1);
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetArea()
        {
            double perimeter = GetPerimeter() / 2;

            return Math.Sqrt(perimeter * (perimeter - side1) * (perimeter - side2) * (perimeter - side3));
        }

        public double GetPerimeter()
        {
            return side1 + side2 + side3;
        }

        public override string ToString()
        {
            return $"Triangle: x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2}, x3 = {x3}, y3 = {y3}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType != GetType)
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return x1 == triangle.x1 && y1 == triangle.y1 && x2 == triangle.x2 && y2 == triangle.y2 && x3 == triangle.x3 && y3 == triangle.y3;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            return prime * hash + y3.GetHashCode();
        }
    }
}
