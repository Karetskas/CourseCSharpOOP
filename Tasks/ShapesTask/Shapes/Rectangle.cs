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
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Rectangle: width = {Width}, height = {Height}";
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

            return Width == rectangle.Width && Height == rectangle.Height;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();
            return prime * hash + Width.GetHashCode();
        }
    }
}
