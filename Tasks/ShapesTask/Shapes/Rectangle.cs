namespace Academits.Karetskas.ShapesTask.Shapes
{
    public sealed class Rectangle : IShape
    {
        private double width;
        private double height;

        public double Width
        {
            get => width;

            set => width = value < 0 ? 0 : value;
        }

        public double Height
        {
            get => height;

            set => height = value < 0 ? 0 : value;
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
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
            return 2 * (width + height);
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

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Rectangle rectangle = (Rectangle)obj;

            return Width == rectangle.Width && Height == rectangle.Height;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            hash = prime * hash + width.GetHashCode();
            return prime * hash + height.GetHashCode();
        }
    }
}
