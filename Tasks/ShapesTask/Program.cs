using System;

namespace Academits.Karetskas.ShapesTask
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapesArray =
            {
                new Square(12.4),
                new Triangle(10, 12, 31.1, -4, -12.9, 3),
                new Rectangle(17.1, 12),
                new Circle(7.3),
                new Square(12.39999),
                new Square(12.40001),
                new Triangle(10, 12, 31.1, -4, -12.9, 2.99),
                new Triangle(10, 12, 31.1, -4, -12.9, 3.01),
                new Rectangle(17.1, 11.999),
                new Rectangle(17.1, 12.001),
                new Circle(7.299),
                new Circle(7.301)
            };

            IShape? shape = GetShapeMaxArea(shapesArray);

            Console.WriteLine($"The shape with the largest area is the {shape}.");
            Console.WriteLine($"Its area is {shape.GetArea():f4} sentimeters square.");
            Console.WriteLine();

            const int secondPlace = 2;
            shape = GetShapePerimeter(shapesArray, secondPlace);

            if (shape is null)
            {
                Console.WriteLine("Shape is null.");
            }
            else
            {
                Console.WriteLine($"The shape with the second largest perimeter is {shape}.");
                Console.WriteLine($"Its perimeter is {shape.GetPerimeter()}");
            }
        }

        private static IShape GetShapeMaxArea(IShape[] shapesArray)
        {
            Array.Sort(shapesArray, new ShapesAreaComparer());

            return shapesArray[^1];
        }

        private static IShape? GetShapePerimeter(IShape[] shapesArray, int ordinalNumberStartingFromLargest)
        {
            if (ordinalNumberStartingFromLargest > shapesArray.Length || ordinalNumberStartingFromLargest < 1)
            {
                return null;
            }

            Array.Sort(shapesArray, new ShapesPerimeterComparer());

            return shapesArray[^ordinalNumberStartingFromLargest];
        }
    }
}