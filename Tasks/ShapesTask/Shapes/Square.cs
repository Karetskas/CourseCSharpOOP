namespace Academits.Karetskas.ShapesTask.Shapes
{
    public sealed class Square : IShape
    {
        private double sideLength;

        public double SideLength
        {
            get => sideLength;

            set => sideLength = value < 0 ? 0 : value;
        }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public override string ToString()
        {
            return $"Square: Side length = {SideLength}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return false;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Square square = (Square)obj;

            return SideLength == square.SideLength;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            return prime * hash + SideLength.GetHashCode();
        }
    }
}
