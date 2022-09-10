using System;
using System.Collections.Generic;
using Academits.Karetskas.VectorTask;

namespace Academits.Karetskas.MatrixTask
{
    public sealed class Matrix
    {
        private Vector[] _vectorsMatrix;

        public int Rows => _vectorsMatrix?.Length ?? 0;

        public int Columns => _vectorsMatrix?[0].Size ?? 0;

        public Vector this[int index, ElementsOrder elementsOrder]
        {
            get
            {
                if (elementsOrder == ElementsOrder.horizontal)
                {
                    if (index < 0 || index >= _vectorsMatrix.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), $"Index out of range of array. " +
                            $"Valid range is from 0 to {_vectorsMatrix.Length - 1}.");
                    }

                    return new Vector(_vectorsMatrix[index]);
                }

                if (index < 0 || index >= _vectorsMatrix[0].Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Index out of range of array. " +
                        $"Valid range is from 0 to {_vectorsMatrix[0].Size - 1}.");
                }

                Vector vector = new Vector(_vectorsMatrix.Length);

                for (int i = 0; i < _vectorsMatrix.Length; i++)
                {
                    vector[i] = _vectorsMatrix[i][index];
                }

                return vector;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value), $"Argument vector is null.");
                }

                if (elementsOrder == ElementsOrder.horizontal)
                {
                    if (index < 0 || index >= _vectorsMatrix.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), $"Index out of range of array. " +
                            $"Valid range is from 0 to {_vectorsMatrix.Length - 1}.");
                    }

                    if (value.Size != _vectorsMatrix[0].Size)
                    {
                        throw new ArgumentException($"Argument \"{nameof(value)}.{nameof(value.Size)}\" is the wrong size.", nameof(value));
                    }

                    _vectorsMatrix[index] = new Vector(value);

                    return;
                }

                if (index < 0 || index >= _vectorsMatrix[0].Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Index out of range of array. " +
                        $"Valid range is from 0 to {_vectorsMatrix[0].Size - 1}.");
                }

                if (value.Size != _vectorsMatrix.Length)
                {
                    throw new ArgumentException($"Argument \"{nameof(value)}.{nameof(value.Size)}\" is the wrong size.", nameof(value));
                }

                for (int i = 0; i < _vectorsMatrix.Length; i++)
                {
                    _vectorsMatrix[i][index] = value[i];
                }
            }
        }

        public Matrix(int rows, int columns)
        {
            if (rows == 0)
            {
                throw new ArgumentException($"Argument \"{nameof(rows)}\" = 0.", nameof(rows));
            }

            _vectorsMatrix = new Vector[rows];

            for (int i = 0; i < _vectorsMatrix.Length; i++)
            {
                _vectorsMatrix[i] = new Vector(columns);
            }
        }

        public Matrix(double[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), $"Argument \"{nameof(array)}\" is null.");
            }

            const int firstDimension = 0;
            const int secondDimension = 1;

            int firstDimensionLength = array.GetLength(firstDimension);
            int secondDimensionLength = array.GetLength(secondDimension);

            if (firstDimensionLength == 0)
            {
                throw new ArgumentException($"Argument \"{nameof(firstDimensionLength)}\" = 0.", nameof(array));
            }

            _vectorsMatrix = new Matrix(firstDimensionLength, secondDimensionLength)._vectorsMatrix;

            for (int i = 0; i < firstDimensionLength; i++)
            {
                for (int j = 0; j < secondDimensionLength; j++)
                {
                    _vectorsMatrix[i][j] = array[i, j];
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            _vectorsMatrix = new Vector[matrix._vectorsMatrix.Length];

            for (int i = 0; i < matrix._vectorsMatrix.Length; i++)
            {
                _vectorsMatrix[i] = new Vector(matrix._vectorsMatrix[i]);
            }
        }

        public Matrix(Vector[]? vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException(nameof(vectorsArray), $"Argument \"{nameof(vectorsArray)}\" is null.");
            }

            _vectorsMatrix = new Vector[vectorsArray.Length];

            int maxSize = int.MinValue;

            foreach (Vector vector in vectorsArray)
            {
                maxSize = Math.Max(maxSize, vector.Size);
            }

            Vector maxSizeVector = new Vector(maxSize);

            for (int i = 0; i < _vectorsMatrix.Length; i++)
            {
                _vectorsMatrix[i] = maxSizeVector + vectorsArray[i];
            }
        }

        public void Transpose()
        {
            Matrix matrix = new Matrix(Columns, Rows);

            for (int i = 0; i < _vectorsMatrix.Length; i++)
            {
                matrix[i, ElementsOrder.vertical] = _vectorsMatrix[i];
            }

            _vectorsMatrix = matrix._vectorsMatrix;
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < Rows; i++)
            {
                _vectorsMatrix[i] *= number;
            }
        }

        public Vector GetProductOnVector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            if (vector.Size != _vectorsMatrix[0].Size)
            {
                throw new ArgumentException($"Count of rows of the vector is not equal to count of columns of the matrix.", nameof(vector));
            }

            Vector columnVector = new Vector(_vectorsMatrix.Length);

            for (int i = 0; i < _vectorsMatrix.Length; i++)
            {
                columnVector[i] = Vector.GetScalarProduct(_vectorsMatrix[i], vector);
            }

            return columnVector;
        }

        public void Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            if (matrix.Columns != Columns)
            {
                throw new ArgumentException($"Count of columns of the matriсes is not equal.", nameof(matrix));
            }

            if (matrix.Rows != Rows)
            {
                throw new ArgumentException($"Count of rows of the matrices is not equal.", nameof(matrix));
            }

            for (int i = 0; i < _vectorsMatrix.Length; i++)
            {
                _vectorsMatrix[i] += matrix._vectorsMatrix[i];
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            if (matrix.Columns != Columns)
            {
                throw new ArgumentException($"Count of columns of the matriсes is not equal.", nameof(matrix));
            }

            if (matrix.Rows != Rows)
            {
                throw new ArgumentException($"Count of rows of the matrices is not equal.", nameof(matrix));
            }

            for (int i = 0; i < _vectorsMatrix.Length; i++)
            {
                _vectorsMatrix[i] -= matrix._vectorsMatrix[i];
            }
        }

        public double GetDeterminant()
        {
            if (Rows != Columns)
            {
                throw new ArgumentException($"The \"{nameof(Rows)}\" and \"{nameof(Columns)}\" properties are not equal.", $"{nameof(Rows)}, {nameof(Columns)}");
            }

            Matrix matrix = new Matrix(_vectorsMatrix);

            double determinant = 1;

            const double epsilon = 1.0e-10;

            for (int diagonalMatrixIndex = 0; diagonalMatrixIndex < matrix.Rows; diagonalMatrixIndex++)
            {
                if (Math.Abs(matrix[diagonalMatrixIndex, ElementsOrder.horizontal][diagonalMatrixIndex]) <= epsilon)
                {
                    if (!IsChangeInMatrixColumns(matrix, diagonalMatrixIndex, diagonalMatrixIndex))
                    {
                        return 0;
                    }

                    determinant *= -1;
                }

                for (int rowIndex = diagonalMatrixIndex + 1; rowIndex < matrix.Rows; rowIndex++)
                {
                    double commonMultiple = matrix[rowIndex, ElementsOrder.horizontal][diagonalMatrixIndex]
                        / matrix[diagonalMatrixIndex, ElementsOrder.horizontal][diagonalMatrixIndex];

                    matrix[rowIndex, ElementsOrder.horizontal] = matrix[rowIndex, ElementsOrder.horizontal]
                        - matrix[diagonalMatrixIndex, ElementsOrder.horizontal] * commonMultiple;
                }
            }

            for (int i = 0; i < matrix.Rows; i++)
            {
                determinant *= matrix[i, ElementsOrder.horizontal][i];
            }

            return determinant;
        }

        private bool IsChangeInMatrixColumns(Matrix matrix, int row, int column)
        {
            const double epsilon = 1.0e-10;

            for (int j = column + 1; j < matrix!.Columns; j++)
            {
                if (Math.Abs(matrix[row, ElementsOrder.horizontal][j]) > epsilon)
                {
                    Vector temp = matrix[row, ElementsOrder.vertical];

                    matrix[row, ElementsOrder.vertical] = matrix[j, ElementsOrder.vertical];

                    matrix[j, ElementsOrder.vertical] = temp;

                    return true;
                }
            }

            return false;
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            return matrix1 + matrix2;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            return matrix1 - matrix2;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            return matrix1 * matrix2;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException(nameof(matrix1), $"Argument \"{nameof(matrix1)}\" is null.");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), $"Argument \"{nameof(matrix2)}\" is null.");
            }

            if (matrix1.Rows != matrix2.Rows)
            {
                throw new ArgumentException($"Count of rows of the matrices is not equal.", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            if (matrix1.Columns != matrix2.Columns)
            {
                throw new ArgumentException($"Count of columns of the matrices is not equal.", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix matrixSum = new Matrix(matrix1);

            matrixSum.Add(matrix2);

            return matrixSum;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException(nameof(matrix1), $"Argument \"{nameof(matrix1)}\" is null.");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), $"Argument \"{nameof(matrix2)}\" is null.");
            }

            if (matrix1.Rows != matrix2.Rows)
            {
                throw new ArgumentException($"Count of rows of the matrices is not equal.", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            if (matrix1.Columns != matrix2.Columns)
            {
                throw new ArgumentException($"Count of columns of the matrices is not equal.", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix matrixDifference = new Matrix(matrix1);

            matrixDifference.Subtract(matrix2);

            return matrixDifference;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException(nameof(matrix1), $"Argument \"{nameof(matrix1)}\" is null.");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), $"Argument \"{nameof(matrix2)}\" is null.");
            }

            if (matrix1.Columns != matrix2.Rows)
            {
                throw new ArgumentException($"Count of rows of the \"{nameof(matrix1)}\" is not equal to count of columns of the \"{nameof(matrix2)}\".",
                    $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix resultMatrix = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Columns; i++)
            {
                for (int j = 0; j < matrix2.Rows; j++)
                {
                    resultMatrix._vectorsMatrix[j][i] = Vector.GetScalarProduct(matrix1[j, ElementsOrder.horizontal], matrix2[i, ElementsOrder.vertical]);
                }
            }

            return resultMatrix;
        }

        public static Matrix operator *(Matrix matrix, double number)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            Matrix resultMatrix = new Matrix(matrix);

            resultMatrix.MultiplyByScalar(number);

            return resultMatrix;
        }

        public static Matrix operator *(double number, Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            Matrix resultMatrix = new Matrix(matrix);

            resultMatrix.MultiplyByScalar(number);

            return resultMatrix;
        }

        public static Vector operator *(Matrix matrix, Vector vector)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            return matrix.GetProductOnVector(vector);
        }

        public override string ToString()
        {
            return _vectorsMatrix is null ? "NULL" : $"{{{string.Join(", ", (IEnumerable<Vector>)_vectorsMatrix)}}}";
        }
    }
}