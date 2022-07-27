using System;

namespace Academits.Karetskas.RangeTask
{
    public static class UsingRangeClass
    {
        static void Main()
        {
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

            string[,] dataArray = new string[numbersArray.Length, rangesArray.Length];

            for (int i = 0; i < numbersArray.Length; i++)
            {
                for (int j = 0; j < rangesArray.Length; j++)
                {
                    if (rangesArray[j].IsInside(numbersArray[i]))
                    {
                        dataArray[i, j] = "+";

                        continue;
                    }

                    dataArray[i, j] = "-";
                }
            }

            string[] rows = ConvertArrayToStringsArray(numbersArray);
            string[] columns = ConvertArrayToStringsArray(rangesArray);

            Table table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"isInside\" function.");

            Console.WriteLine(Environment.NewLine);

            rangesArray = new Range[]
            {
                new Range(5, 10),
                new Range(1, 3),
                new Range(1, 4.9_999_999_999),
                new Range(1, 5),
                new Range(1, 5.0_000_000_001),
                new Range(1, 7),
                new Range(4.9_999_999_999, 7),
                new Range(5, 7),
                new Range(5.0_000_000_001, 7),
                new Range(6, 8),
                new Range(7, 9.9_999_999_999),
                new Range(7, 10),
                new Range(7, 10.0_000_000_001),
                new Range(7, 16),
                new Range(9.9_999_999_999, 16),
                new Range(10, 16),
                new Range(10.0_000_000_001, 16),
                new Range(13, 16)
            };

            Range range = new Range(5, 10);

            dataArray = new string[rangesArray.Length, 1];

            for (int i = 0; i < rangesArray.Length; i++)
            {
                Range? intersection = range.GetIntersection(rangesArray[i]);

                if (intersection == null)
                {
                    dataArray[i, 0] = "null";

                    continue;
                }

                dataArray[i, 0] = intersection.ToString();
            }

            rows = ConvertArrayToStringsArray(rangesArray);
            columns = new string[] { range.ToString() };

            table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"GetIntersection()\" function.");

            Console.WriteLine(Environment.NewLine);

            for (int i = 0; i < rangesArray.Length; i++)
            {
                Range[] union = range.GetUnion(rangesArray[i]);

                if (union.Length == 2)
                {
                    dataArray[i, 0] = "[" + union[0] + ", " + union[1] + "]";

                    continue;
                }

                dataArray[i, 0] = "[" + union[0] + "]";
            }

            table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"GetUnion()\" function.");

            Console.WriteLine(Environment.NewLine);

            rangesArray = new Range[]
            {
                new Range(-8, -6),
                new Range(-8, -5.0_000_000_001),
                new Range(-8, -5),
                new Range(-8, -4.9_999_999_999),
                new Range(-8, -2),
                new Range(-8, 0),
                new Range(-8, 5),
                new Range(-8, 9),
                new Range(-8, 9.9_999_999_999),
                new Range(-8, 10),
                new Range(-8, 10.0_000_000_001),
                new Range(-8, 12),
                new Range(-5.0_000_000_001, 12),
                new Range(-5, 12),
                new Range(-4.9_999_999_999, 12),
                new Range(-2, 12),
                new Range(0, 12),
                new Range(5, 12),
                new Range(9, 12),
                new Range(9.9_999_999_999, 12),
                new Range(10, 12),
                new Range(10.0_000_000_001, 12),
                new Range(11, 12)
            };

            range = new Range(-5, 10);

            dataArray = new string[rangesArray.Length, 1];

            for (int i = 0; i < rangesArray.Length; i++)
            {
                Range[] difference = range.GetDifference(rangesArray[i]);

                if (difference.Length == 2)
                {
                    dataArray[i, 0] = "[" + difference[0] + ", " + difference[1] + "]";

                    continue;
                }

                if (difference.Length == 1)
                {
                    dataArray[i, 0] = "[" + difference[0] + "]";

                    continue;
                }

                dataArray[i, 0] = "[]";
            }

            columns = new string[] { range.ToString() };
            rows = ConvertArrayToStringsArray(rangesArray);

            table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"GetDifference\" function for negative and positive ranges.");
        }

        private static string[] ConvertArrayToStringsArray(double[] array)
        {
            string[] resultArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[i].ToString();
            }

            return resultArray;
        }

        private static string[] ConvertArrayToStringsArray(Range[] array)
        {
            string[] resultArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[i].ToString();
            }

            return resultArray;
        }
    }
}