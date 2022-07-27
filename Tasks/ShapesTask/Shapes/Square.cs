namespace Academits.Karetskas.ShapesTask
{
    public sealed class Square : IShape
    {
        private readonly double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength < 0 ? 0 : sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * sideLength;
        }

        public override string ToString()
        {
            return $"Square: Side length = {sideLength}";
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

            return sideLength == square.sideLength;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            return prime * hash + sideLength.GetHashCode();
        }
    }
}
