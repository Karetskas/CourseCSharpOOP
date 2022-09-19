using System;
using Academits.Karetskas.VectorTask;

namespace Academits.Karetskas.MatrixTask
{
    internal class Program
    {
        private enum PrintType
        {
            Write,
            WriteLine
        }

        static void Main()
        {
            Matrix zeroMatrix = new Matrix(3, 4);

            PrintToConsole(ConsoleColor.Yellow, "Create zero matrix:", $"{nameof(zeroMatrix)} = {zeroMatrix}.", PrintType.WriteLine);

            PrintToConsole(ConsoleColor.Yellow, "Print count of columns and rows in the zero matrix:",
                $"{nameof(zeroMatrix.ColumnsCount)} = {zeroMatrix.ColumnsCount}; {nameof(zeroMatrix.RowsCount)} = {zeroMatrix.RowsCount}.", PrintType.WriteLine);

            Vector[] vectorsArray =
            {
                new Vector(new double[] { 1, 1, 1 }),
                new Vector(new double[] { 2, 2, 2, 2 }),
                new Vector(new double[] { 3 })
            };

            Matrix vectorsArrayToMatrix = new Matrix(vectorsArray);

            PrintToConsole(ConsoleColor.Yellow, "Copying array of vectors to matrix:",
                $"\"{nameof(vectorsArrayToMatrix)}\": {nameof(vectorsArrayToMatrix)} = {vectorsArrayToMatrix}.", PrintType.WriteLine);

            Vector[] vectorsArrayForMatrix =
            {
                new Vector(new double[] { 1 }),
                new Vector(new double[] { 2, 2 }),
                new Vector(new double[] { 3, 3, 3})
            };

            Matrix matrix = new Matrix(vectorsArrayForMatrix);
            Matrix matrixToMatrix = new Matrix(matrix);

            PrintToConsole(ConsoleColor.Yellow, "Copying matrix to matrix:",
                $"Matrix \"{nameof(matrixToMatrix)}\": {matrixToMatrix}.", PrintType.WriteLine);

            double[,] array1 =
            {
                { 1, 2, 3, 4 },
                { 4, 5, 6, 7 },
                { 7, 8, 9, 10 }
            };

            Matrix arrayToMatrix1 = new Matrix(array1);

            PrintToConsole(ConsoleColor.Yellow, "Copying array to matrix:",
                $"Matrix \"{nameof(arrayToMatrix1)}\" = {arrayToMatrix1}.", PrintType.WriteLine);

            double[,] array2 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 }
            };

            Matrix arrayToMatrix2 = new Matrix(array2);

            PrintToConsole(ConsoleColor.Yellow, "Copying array to matrix:",
                $"Matrix \"{nameof(arrayToMatrix2)}\" = {arrayToMatrix2}.", PrintType.WriteLine);

            double[,] array3 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 }
            };

            Matrix matrixForGetData = new Matrix(array3);

            PrintToConsole(ConsoleColor.DarkYellow, "Get vertical and horizontal vectors of matrix:", "", PrintType.Write);

            PrintToConsole(ConsoleColor.DarkYellow, "", "{", PrintType.Write);

            for (int i = 0; i < matrixForGetData.RowsCount; i++)
            {
                PrintToConsole(ConsoleColor.DarkYellow, "", $"{matrixForGetData[i]}", PrintType.Write);

                if (i + 1 != matrixForGetData.RowsCount)
                {
                    PrintToConsole(ConsoleColor.DarkYellow, "", ", ", PrintType.Write);
                }
            }

            PrintToConsole(ConsoleColor.DarkYellow, "", "}", PrintType.Write);
            Console.WriteLine();

            PrintToConsole(ConsoleColor.Yellow, "", "{", PrintType.Write);

            for (int i = 0; i < matrixForGetData.ColumnsCount; i++)
            {
                PrintToConsole(ConsoleColor.Yellow, "", $"{matrixForGetData.GetColumnVector(i)}", PrintType.Write);

                if (i + 1 != matrixForGetData.ColumnsCount)
                {
                    PrintToConsole(ConsoleColor.Yellow, "", ", ", PrintType.Write);
                }
            }

            PrintToConsole(ConsoleColor.Yellow, "", "}", PrintType.WriteLine);

            double[,] array4 =
            {
                { 9, 10, 11, 12 },
                { 11, 12, 13, 14 },
                { 12, 13, 14, 15 }
            };

            Matrix matrixForSetData = new Matrix(array4);

            PrintToConsole(ConsoleColor.DarkYellow, "Set vertical and horizontal vectors to matrix:",
                $"Matrix before the change: {matrixForSetData}.", PrintType.Write);
            Console.WriteLine();

            matrixForSetData.SetColumnVector(1, new Vector(new double[] { 7, 7, 7 }));

            PrintToConsole(ConsoleColor.Yellow, "", $"Set vertical vector to matrix: {matrixForSetData}.", PrintType.Write);
            Console.WriteLine();

            matrixForSetData[2] = new Vector(new double[] { -9, -9, -9, -9 });

            PrintToConsole(ConsoleColor.Yellow, "", $"Set horizontal vector to matrix: {matrixForSetData}.", PrintType.WriteLine);

            double[,] array5 =
            {
                { 1, 1, 1 },
                { 2, 2, 2 },
                { 3, 3, 3 },
                { 4, 4, 4 },
                { 5, 5, 5 }
            };

            Matrix matrixForTransposition = new Matrix(array5);

            PrintToConsole(ConsoleColor.DarkYellow, "Transposition of matrix:", $"Matrix before the change: {matrixForTransposition}.", PrintType.Write);
            Console.WriteLine();

            matrixForTransposition.Transpose();

            PrintToConsole(ConsoleColor.Yellow, "", $"Matrix after the change: {matrixForTransposition}.", PrintType.WriteLine);

            double[,] array6 =
            {
                {  0,  12, -12, 12,  6 },
                { -3,  -9,   9,  9, -6 },
                {  0,   0,  -2,  4, -2 },
                { -3, -17,  13,  3, -8 },
                {  0,   0,   4, -8,  0 }
            };

            Matrix matrixForFindingDeterminant = new Matrix(array6);

            PrintToConsole(ConsoleColor.DarkYellow, "Calculation of determinant of matrix:",
                $"Determinant \"{nameof(matrixForFindingDeterminant)}\" matrix: {matrixForFindingDeterminant.GetDeterminant()}.", PrintType.WriteLine);

            double[,] array7 =
            {
                { 1, 2, 3 },
                { 1, 2, 3 },
                { 1, 2, 3 }
            };

            Matrix matrixForMultiplyByScalar = new Matrix(array7);

            PrintToConsole(ConsoleColor.DarkYellow, "Multiplying the matrix by scalar:",
                $"Matrix before the change: {matrixForMultiplyByScalar}.", PrintType.Write);
            Console.WriteLine();
            PrintToConsole(ConsoleColor.Yellow, "", $"Matrix * (-3) = {matrixForMultiplyByScalar * -3}.", PrintType.WriteLine);

            double[,] array8 =
            {
                { 2, -1, 3 },
                { 4, 2, 0 },
                { -1, 1, 1 }
            };

            Matrix matrixForMultiplyByVector = new Matrix(array8);

            Vector columnVector = new Vector(new double[] { 1, 2, -1 });

            PrintToConsole(ConsoleColor.DarkYellow, "Matrix * vector:", $"{matrixForMultiplyByVector} * {columnVector} = ", PrintType.Write);
            PrintToConsole(ConsoleColor.Yellow, "", matrixForMultiplyByVector * columnVector, PrintType.WriteLine);

            double[,] array9 =
            {
                { 1, -9, 4 },
                { 6, -5, 4 },
                { 7, 8, 9 }
            };

            Matrix matrixForAddition1 = new Matrix(array9);

            double[,] array10 =
            {
                { 9, 3, 7 },
                { 2, 7, 4 },
                { -7, 4, 3 }
            };

            Matrix matrixForAddition2 = new Matrix(array10);

            PrintToConsole(ConsoleColor.DarkYellow, "Matrices addition:",
                $"{nameof(matrixForAddition1)} + {nameof(matrixForAddition2)} = ", PrintType.Write);
            PrintToConsole(ConsoleColor.Yellow, "", matrixForAddition1 + matrixForAddition2, PrintType.WriteLine);

            double[,] array11 =
            {
                { 1, -9, 4 },
                { 6, -5, 4 },
                { 7, 8, 9 }
            };

            Matrix matrixForSubtraction1 = new Matrix(array11);

            double[,] array12 =
            {
                { 9, 3, 7 },
                { 2, 7, 4 },
                { -7, 4, 3 }
            };

            Matrix matrixForSubtraction2 = new Matrix(array12);

            PrintToConsole(ConsoleColor.DarkYellow, "Matrices subtraction:",
                $"{nameof(matrixForSubtraction1)} - {nameof(matrixForSubtraction2)} = ", PrintType.Write);
            PrintToConsole(ConsoleColor.Yellow, "", matrixForSubtraction1 - matrixForSubtraction2, PrintType.WriteLine);

            double[,] array13 =
            {
                { 1, -9, 4 },
                { 6, -5, 4 },
                { 7, 8, 9 }
            };

            Matrix matrixForProduct1 = new Matrix(array13);

            double[,] array14 =
            {
                { 9, 3, 7 },
                { 2, 7, 4 },
                { -7, 4, 3 }
            };

            Matrix matrixForProduct2 = new Matrix(array14);

            PrintToConsole(ConsoleColor.DarkYellow, "Matrices product:",
                $"{nameof(matrixForProduct1)} * {nameof(matrixForProduct2)} = ", PrintType.Write);
            PrintToConsole(ConsoleColor.Yellow, "", matrixForProduct1 * matrixForProduct2, PrintType.WriteLine);
        }

        private static void PrintToConsole<T>(ConsoleColor color, string title, T text, PrintType printType)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Console.WriteLine(title);
            }

            Console.ForegroundColor = color;

            if (printType == PrintType.Write)
            {
                Console.Write(text);

                Console.ResetColor();

                return;
            }

            Console.WriteLine(text);

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('-', 90));
            Console.ResetColor();
        }
    }
}