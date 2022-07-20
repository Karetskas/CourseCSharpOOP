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

            string[] rows = ConvertArrayToString(numbersArray);
            string[] columns = ConvertArrayToString(rangesArray);

            Table table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"isInside\" function.");

            Console.WriteLine(Environment.NewLine);

            rangesArray = new Range[]
            {
                new Range(5, 5),
                new Range(10, 10),
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
                Range? resultIntersection = range.GetRangesIntersection(rangesArray[i]);

                if (resultIntersection == null)
                {
                    dataArray[i, 0] = "null";

                    continue;
                }

                dataArray[i, 0] = resultIntersection.ToString();
            }

            rows = ConvertArrayToString(rangesArray);
            columns = new string[] { range.ToString() };

            table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"GetRangesIntersection()\" function.");

            Console.WriteLine(Environment.NewLine);

            for (int i = 0; i < rangesArray.Length; i++)
            {
                Range[] resultJoin = range.GetRangesJoin(rangesArray[i]);

                if (resultJoin.Length == 2)
                {
                    dataArray[i, 0] = resultJoin[0].ToString() + ", " + resultJoin[1].ToString();

                    continue;
                }

                dataArray[i, 0] = resultJoin[0].ToString();
            }

            table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"GetRangesJoin()\" function.");

            Console.WriteLine(Environment.NewLine);

            Range[] arrayColumnsRange =
            {
                new Range(5, 10),
                new Range(5, 5),
                new Range(10, 10)
            };

            dataArray = new string[rangesArray.Length, arrayColumnsRange.Length];

            for (int i = 0; i < rangesArray.Length; i++)
            {
                for (int j = 0; j < arrayColumnsRange.Length; j++)
                {
                    Range[] resultDifference = arrayColumnsRange[j].GetRangesDifference(rangesArray[i]);

                    if (resultDifference.Length == 2)
                    {
                        dataArray[i, j] = resultDifference[0].ToString() + ", " + resultDifference[1].ToString();

                        continue;
                    }

                    if (resultDifference.Length == 1)
                    {
                        dataArray[i, j] = resultDifference[0].ToString();

                        continue;
                    }

                    dataArray[i, j] = "0";
                }
            }

            columns = ConvertArrayToString(arrayColumnsRange);

            table = new Table(columns, rows, dataArray);
            table.Output("Demonstration of the \"GetRangeDifference\" function.");
        }

        private static string[] ConvertArrayToString(double[] array)
        {
            string[] resultArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[i].ToString();
            }

            return resultArray;
        }

        private static string[] ConvertArrayToString(Range[] array)
        {
            string[] resultArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = "(" + Convert.ToString(array[i].From) + "; " + Convert.ToString(array[i].To) + ")";
            }

            return resultArray;
        }
    }
}