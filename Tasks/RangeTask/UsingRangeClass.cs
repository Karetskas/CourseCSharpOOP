using System;

namespace Academits.Karetskas.RangeTask
{
    public static class UsingRangeClass
    {
        static void Main()
        {
            Console.WriteLine("The program for working with \"Range\" class.");
            Console.WriteLine();

            Range[] rangesArray =
            {
                new Range(5, 10),
                new Range(-5, 10),
                new Range(-10, -5)
            };

            double[] numbersArray =
            {
                3,
                12,
                7,
                -3,
                -12,
                -7,
                4.9_999_999_999,
                4.99_999_999_999,
                5.0_000_000_001,
                5.00_000_000_001,
                9.9_999_999_999,
                9.99_999_999_999,
                10.0_000_000_001,
                10.00_000_000_001,
                -4.9_999_999_999,
                -4.99_999_999_999,
                -5.0_000_000_001,
                -5.00_000_000_001,
                -9.9_999_999_999,
                -9.99_999_999_999,
                -10.0_000_000_001,
                -10.00_000_000_001
            };

            Console.Write("{0, 18}", "Numbers / Ranges |");

            for (int i = 0; i < rangesArray.Length; i++)
            {
                string rangeAsString = rangesArray[i].From.ToString() + "; " + rangesArray[i].To.ToString() + " |";
                Console.Write("{0, 10}", rangeAsString);
            }

            Console.WriteLine();

            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.Write("{0, 18}", numbersArray[i] + " |");

                for (int j = 0; j < rangesArray.Length; j++)
                {
                    if (rangesArray[j].IsInside(numbersArray[i]))
                    {
                        Console.Write("{0, 10}", "+ |");

                        continue;
                    }

                    Console.Write("{0, 10}", "- |");
                }

                Console.WriteLine();
            }
        }
    }
}