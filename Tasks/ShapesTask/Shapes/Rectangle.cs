namespace Academits.Karetskas.ShapesTask
{
    public sealed class Rectangle : IShape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height)
        {
            this.width = width < 0 ? 0 : width;
            this.height = height < 0 ? 0 : height;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return 2 * width + 2 * height;
        }

        public override string ToString()
        {
            return $"Rectangle: width = {width}, height = {height}";
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

            Rectangle rectangle = (Rectangle)obj;

            return width == rectangle.width && height == rectangle.height;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            hash = prime * hash + width.GetHashCode();
            return prime * hash + width.GetHashCode();
        }
    }
}
