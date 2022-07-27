using System;

namespace Academits.Karetskas.RangeTask
{
    public sealed class Table
    {
        private readonly string[,] table;

        public Table(string[] columns, string[] rows, string[,] dataArray)
        {
            int countRows = rows.Length + 1;
            int countColumns = columns.Length + 1;

            table = new string[countRows, countColumns];

            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        table[0, 0] = "";

                        continue;
                    }

                    if (i == 0)
                    {
                        table[i, j] = columns[j - 1];

                        continue;
                    }

                    if (j == 0)
                    {
                        table[i, j] = rows[i - 1];

                        continue;
                    }

                    table[i, j] = dataArray[i - 1, j - 1];
                }
            }
        }

        private static int GetMaxArrayStringLength(string[,] array)
        {
            int maxArrayStringLength = 0;

            foreach (string text in array)
            {
                if (text.Length > maxArrayStringLength)
                {
                    maxArrayStringLength = text.Length;
                }
            }

            return maxArrayStringLength;
        }

        private static (int, int) GetTextAlignmentCenter(int maxRowLength, int maxTextLength)
        {
            int spacesCount = maxRowLength - maxTextLength;

            if (spacesCount <= 0)
            {
                return (0, 0);
            }

            int spacesAfterText = spacesCount / 2;
            int spacesBeforeText = spacesCount - spacesAfterText;

            return (spacesBeforeText, spacesAfterText);
        }

        public void Output(string tableName)
        {
            int maxRowLength = GetMaxArrayStringLength(table);

            int maxTableWidth = maxRowLength * table.GetLength(1);
            int maxTableWeightAndSeparator = maxTableWidth + table.GetLength(1) * 2;

            if (maxTableWeightAndSeparator <= 200 && Console.WindowWidth < maxTableWeightAndSeparator)
            {
                Console.WindowWidth = maxTableWeightAndSeparator;
            }

            int spacesBeforeText = GetTextAlignmentCenter(maxTableWidth, tableName.Length).Item1;
            int spacesAfterText = GetTextAlignmentCenter(maxTableWidth, tableName.Length).Item2;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(new string(' ', spacesBeforeText) + tableName + new string(' ', spacesAfterText));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', maxTableWeightAndSeparator));

            for (int i = 0; i < table.GetLength(1); i++)
            {
                spacesBeforeText = GetTextAlignmentCenter(maxRowLength, table[0, i].Length).Item1;
                spacesAfterText = GetTextAlignmentCenter(maxRowLength, table[0, i].Length).Item2;

                Console.Write(new string(' ', spacesBeforeText) + table[0, i] + new string(' ', spacesAfterText) + " |");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', maxTableWeightAndSeparator));
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    spacesBeforeText = GetTextAlignmentCenter(maxRowLength, table[i, j].Length).Item1;
                    spacesAfterText = GetTextAlignmentCenter(maxRowLength, table[i, j].Length).Item2;

                    Console.Write(new string(' ', spacesBeforeText) + table[i, j] + new string(' ', spacesAfterText) + " |");
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', maxTableWeightAndSeparator));
            Console.ResetColor();
        }
    }
}
