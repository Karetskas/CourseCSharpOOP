using System;

namespace Academits.Karetskas.RangeTask
{
    public static class RangeTest
    {
        static void Main()
        {
            Range[] rangesArrayForTesting =
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

            string[,] dataArray = new string[numbersArray.Length, rangesArrayForTesting.Length];

            for (int i = 0; i < numbersArray.Length; i++)
            {
                for (int j = 0; j < rangesArrayForTesting.Length; j++)
                {
                    if (rangesArrayForTesting[j].IsInside(numbersArray[i]))
                    {
                        dataArray[i, j] = "+";

                        continue;
                    }

                    dataArray[i, j] = "-";
                }
            }

            string[] rows = ConvertToStringsArray(numbersArray);
            string[] columns = ConvertToStringsArray(rangesArrayForTesting);

            Table rangesMembershipTable = new Table(columns, rows, dataArray);
            rangesMembershipTable.PrintToConsole("Demonstration of the \"isInside\" function.");

            Console.WriteLine(Environment.NewLine);

            Range[] rangesForIntersection = new Range[]
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

            dataArray = new string[rangesForIntersection.Length, 1];

            for (int i = 0; i < rangesForIntersection.Length; i++)
            {
                Range? intersection = range.GetIntersection(rangesForIntersection[i]);

                if (intersection == null)
                {
                    dataArray[i, 0] = "null";

                    continue;
                }

                dataArray[i, 0] = intersection.ToString();
            }

            rows = ConvertToStringsArray(rangesForIntersection);
            columns = new string[] { range.ToString() };

            Table rangesIntersectionsTable = new Table(columns, rows, dataArray);
            rangesIntersectionsTable.PrintToConsole("Demonstration of the \"GetIntersection()\" function.");

            Console.WriteLine(Environment.NewLine);

            Range[] rangesForUnion = new Range[rangesArrayForTesting.Length];

            rangesArrayForTesting.CopyTo(rangesForUnion, 0);

            for (int i = 0; i < rangesForUnion.Length; i++)
            {
                Range[] union = range.GetUnion(rangesForUnion[i]);

                if (union.Length == 2)
                {
                    dataArray[i, 0] = "[" + union[0] + ", " + union[1] + "]";

                    continue;
                }

                dataArray[i, 0] = "[" + union[0] + "]";
            }

            Table rangesUnionTable = new Table(columns, rows, dataArray);
            rangesUnionTable.PrintToConsole("Demonstration of the \"GetUnion()\" function.");

            Console.WriteLine(Environment.NewLine);

            Range[] rangesForDifference = new Range[]
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

            dataArray = new string[rangesForDifference.Length, 1];

            for (int i = 0; i < rangesForDifference.Length; i++)
            {
                Range[] difference = range.GetDifference(rangesForDifference[i]);

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
            rows = ConvertToStringsArray(rangesForDifference);

            Table rangesDifferenceTable = new Table(columns, rows, dataArray);
            rangesDifferenceTable.PrintToConsole("Demonstration of the \"GetDifference\" function for negative and positive ranges.");
        }

        private static string[] ConvertToStringsArray(double[] array)
        {
            string[] resultArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[i].ToString();
            }

            return resultArray;
        }

        private static string[] ConvertToStringsArray(Range[] array)
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