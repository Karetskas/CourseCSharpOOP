using System;
using System.Collections.Generic;
using Academits.Karetskas.VectorTask;

namespace Academits.Karetskas.MatrixTask
{
    public sealed class Matrix
    {
        private Vector[] _rows;

        public int RowsCount => _rows.Length;

        public int ColumnsCount => _rows[0].Size;

        public Vector this[int index]
        {
            get
            {
                if (index < 0 || index >= _rows.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range for the count of matrix rows. "
                        + $"Valid range is from 0 to {_rows.Length - 1}.");
                }

                return new Vector(_rows[index]);
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value), "Argument vector is null.");
                }

                if (index < 0 || index >= _rows.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range for the count of matrix rows. "
                        + $"Valid range is from 0 to {_rows.Length - 1}.");
                }

                if (value.Size != ColumnsCount)
                {
                    throw new ArgumentException($"Argument \"{nameof(value)}.{nameof(value.Size)}\" is the wrong size.", nameof(value));
                }

                _rows[index] = new Vector(value);
            }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException("The count of rows in the matrix must not be <= 0.", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException("The count of columns in the matrix must not be <= 0.", nameof(columnsCount));
            }

            _rows = new Vector[rowsCount];

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new Vector(columnsCount);
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

            int rowsCount = array.GetLength(firstDimension);
            int columnsCount = array.GetLength(secondDimension);

            if (rowsCount == 0)
            {
                throw new ArgumentException("The first dimension of array must not be 0.", nameof(array));
            }

            if (columnsCount == 0)
            {
                throw new ArgumentException("The second dimension of array must not be 0.", nameof(array));
            }

            _rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                Vector vector = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    vector[j] = array[i, j];
                }

                _rows[i] = vector;
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            _rows = new Vector[matrix._rows.Length];

            for (int i = 0; i < matrix._rows.Length; i++)
            {
                _rows[i] = new Vector(matrix._rows[i]);
            }
        }

        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException(nameof(vectorsArray), $"Argument \"{nameof(vectorsArray)}\" is null.");
            }

            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException(nameof(vectorsArray), "The array of vectors must not be 0.");
            }

            _rows = new Vector[vectorsArray.Length];

            int maxSize = 0;

            foreach (Vector vector in vectorsArray)
            {
                maxSize = Math.Max(maxSize, vector.Size);
            }

            Vector maxSizeVector = new Vector(maxSize);

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i] = maxSizeVector + vectorsArray[i];
            }
        }

        public Vector GetColumnVector(int index)
        {
            if (index < 0 || index >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range for the count of matrix columns. "
                    + $"Valid range is from 0 to {ColumnsCount - 1}.");
            }

            Vector vector = new Vector(_rows.Length);

            for (int i = 0; i < _rows.Length; i++)
            {
                vector[i] = _rows[i][index];
            }

            return vector;
        }

        public void SetColumnVector(int index, Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "Argument vector is null.");
            }

            if (index < 0 || index >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range for the count of matrix columns. "
                    + $"Valid range is from 0 to {ColumnsCount - 1}.");
            }

            if (vector.Size != _rows.Length)
            {
                throw new ArgumentException($"Argument \"{nameof(vector)}.{nameof(vector.Size)}\" is the wrong size.", nameof(vector));
            }

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i][index] = vector[i];
            }
        }

        public void Transpose()
        {
            Vector[] vectors = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                vectors[i] = GetColumnVector(i);
            }

            _rows = vectors;
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                _rows[i].MultiplyByScalar(number);
            }
        }

        public void GetProduct(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            if (vector.Size != ColumnsCount)
            {
                throw new ArgumentException("Count of rows of the vector is not equal to count of columns of the matrix. "
                    + $"The size of vector = {vector.Size} and count of columns of the matrix = {ColumnsCount}.", nameof(vector));
            }

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new Vector(new double[1]
                {
                    Vector.GetScalarProduct(_rows[i], vector)
                });
            }
        }

        private bool AreSameSize(Matrix matrix)
        {
            if (matrix.ColumnsCount != ColumnsCount || matrix.RowsCount != RowsCount)
            {
                return false;
            }

            return true;
        }

        public void Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            if (!AreSameSize(matrix))
            {
                throw new ArgumentException($"The matrix has different sizes. The current size matrix ({RowsCount}x{ColumnsCount}) "
                    + $"and the size argument matrix ({matrix.RowsCount}x{matrix.ColumnsCount}).", nameof(matrix));
            }

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i].Add(matrix._rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            if (!AreSameSize(matrix))
            {
                throw new ArgumentException($"The matrix has different sizes. The current size matrix ({RowsCount}x{ColumnsCount}) "
                    + $"and the size argument matrix ({matrix.RowsCount}x{matrix.ColumnsCount}).", nameof(matrix));
            }

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i].Subtract(matrix._rows[i]);
            }
        }

        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new InvalidOperationException($"The \"{nameof(RowsCount)}\" = {RowsCount} "
                    + $"and \"{nameof(ColumnsCount)}\" = {ColumnsCount} properties are not equal.");
            }

            Matrix matrix = new Matrix(_rows);

            double determinant = 1;

            const double epsilon = 1.0e-10;

            for (int diagonalMatrixIndex = 0; diagonalMatrixIndex < matrix.RowsCount; diagonalMatrixIndex++)
            {
                if (Math.Abs(matrix[diagonalMatrixIndex][diagonalMatrixIndex]) <= epsilon)
                {
                    if (!IsChangeInMatrixColumns(matrix, diagonalMatrixIndex, diagonalMatrixIndex))
                    {
                        return 0;
                    }

                    determinant *= -1;
                }

                for (int rowIndex = diagonalMatrixIndex + 1; rowIndex < matrix.RowsCount; rowIndex++)
                {
                    double commonMultiple = matrix[rowIndex][diagonalMatrixIndex]
                        / matrix[diagonalMatrixIndex][diagonalMatrixIndex];

                    matrix[rowIndex] = matrix[rowIndex]
                        - matrix[diagonalMatrixIndex] * commonMultiple;
                }
            }

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                determinant *= matrix[i][i];
            }

            return determinant;
        }

        private static bool IsChangeInMatrixColumns(Matrix matrix, int rowIndex, int columnIndex)
        {
            const double epsilon = 1.0e-10;

            for (int currentRowIndex = rowIndex; currentRowIndex < matrix._rows.Length; currentRowIndex++)
            {
                if (Math.Abs(matrix._rows[currentRowIndex][columnIndex]) > epsilon)
                {
                    for (int currentColumnIndex = 0; currentColumnIndex < matrix.ColumnsCount; currentColumnIndex++)
                    {
                        (matrix._rows[rowIndex][currentColumnIndex], matrix._rows[currentRowIndex][currentColumnIndex])
                            = (matrix._rows[currentRowIndex][currentColumnIndex], matrix._rows[rowIndex][currentColumnIndex]);
                    }

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

            if (!matrix1.AreSameSize(matrix2))
            {
                throw new ArgumentException($"The matrix has different sizes. The \"{nameof(matrix1)}\" = ({matrix1.RowsCount}x{matrix1.ColumnsCount}) "
                    + $"and the \"{matrix2}\" = ({matrix2.RowsCount}x{matrix2.ColumnsCount}).", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix matricesSum = new Matrix(matrix1);

            matricesSum.Add(matrix2);

            return matricesSum;
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

            if (!matrix1.AreSameSize(matrix2))
            {
                throw new ArgumentException($"The matrix has different sizes. The \"{nameof(matrix1)}\" = ({matrix1.RowsCount}x{matrix1.ColumnsCount}) "
                    + $"and the \"{matrix2}\" = ({matrix2.RowsCount}x{matrix2.ColumnsCount}).", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix matricesDifference = new Matrix(matrix1);

            matricesDifference.Subtract(matrix2);

            return matricesDifference;
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

            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Count of rows of the \"{nameof(matrix1)}\" = {matrix1.ColumnsCount} is not equal to"
                    + $" count of columns of the \"{nameof(matrix2)}\" = {matrix2.RowsCount}.", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix matricesProduct = new Matrix(matrix1.RowsCount, matrix2.ColumnsCount);

            for (int i = 0; i < matrix1.ColumnsCount; i++)
            {
                for (int j = 0; j < matrix2.RowsCount; j++)
                {
                    matricesProduct._rows[j][i] = Vector.GetScalarProduct(matrix1[j], matrix2.GetColumnVector(i));
                }
            }

            return matricesProduct;
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

        public static Matrix operator *(Matrix matrix, Vector vector)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), $"Argument \"{nameof(matrix)}\" is null.");
            }

            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            Matrix newMatrix = new Matrix(matrix);

            newMatrix.GetProduct(vector);

            return newMatrix;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", (IEnumerable<Vector>)_rows)}}}";
        }
    }
}