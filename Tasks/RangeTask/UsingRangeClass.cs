using System;

namespace Academits.Karetskas
{
    public static class UsingRangeClass
    {
        static void Main()
        {
            Console.WriteLine("The program for working with \"Range\" class.");
            Console.WriteLine();

            Console.Write("Please, enter the first real number: ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please, enter the second real number: ");
            double to = Convert.ToDouble(Console.ReadLine());

            const double epsilon = 1.0e-10;

            if (from - to > epsilon)
            {
                double temp = to;
                to = from;
                from = temp;
            }

            Range range = new Range(from, to);

            Console.Write("Please, enter the real number: ");
            double number = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("The range has a size {0}. ", range.GetLength());

            if (range.IsInside(number))
            {
                Console.WriteLine("Number {0} is part of range.", number);

                return;
            }

            Console.WriteLine("Number {0} isn't part of range.", number);
        }
    }
}