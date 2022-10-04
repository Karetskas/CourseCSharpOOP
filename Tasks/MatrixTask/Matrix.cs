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
                CheckIndex(index, _rows.Length);

                return new Vector(_rows[index]);
            }

            set
            {
                CheckForNull(value);
                CheckIndex(index, _rows.Length);
                CheckVectorSize(value, ColumnsCount);

                _rows[index] = new Vector(value);
            }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"The count of rows in the matrix must not be <= 0. Now the count of rows = {rowsCount}.", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"The count of columns in the matrix must not be <= 0. Now the count of columns = {columnsCount}", nameof(columnsCount));
            }

            _rows = new Vector[rowsCount];

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(double[,] array)
        {
            CheckForNull(array);

            const int firstDimension = 0;
            const int secondDimension = 1;

            int rowsCount = array.GetLength(firstDimension);
            int columnsCount = array.GetLength(secondDimension);

            if (rowsCount == 0)
            {
                throw new ArgumentException($"The first dimension of array must not be 0. Now the first dimension = {rowsCount}.", nameof(array));
            }

            if (columnsCount == 0)
            {
                throw new ArgumentException($"The second dimension of array must not be 0. Now the first dimension = {columnsCount}.", nameof(array));
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
            CheckForNull(matrix);

            _rows = new Vector[matrix._rows.Length];

            for (int i = 0; i < matrix._rows.Length; i++)
            {
                _rows[i] = new Vector(matrix._rows[i]);
            }
        }

        public Matrix(Vector[] vectorsArray)
        {
            CheckForNull(vectorsArray);

            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException(nameof(vectorsArray), $"The array of vectors must not be 0. Now the array of vectors = {vectorsArray.Length}.");
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
            CheckIndex(index, ColumnsCount);

            Vector vector = new Vector(_rows.Length);

            for (int i = 0; i < _rows.Length; i++)
            {
                vector[i] = _rows[i][index];
            }

            return vector;
        }

        public void SetColumnVector(int index, Vector vector)
        {
            CheckForNull(vector);
            CheckIndex(index, ColumnsCount);
            CheckVectorSize(vector, _rows.Length);

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i][index] = vector[i];
            }
        }

        public void Transpose()
        {
            Vector[] columns = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                columns[i] = GetColumnVector(i);
            }

            _rows = columns;
        }

        public void MultiplyByScalar(double number)
        {
            foreach (Vector vector in _rows)
            {
                vector.MultiplyByScalar(number);
            }
        }

        public Vector GetProduct(Vector vector)
        {
            CheckForNull(vector);

            if (vector.Size != ColumnsCount)
            {
                throw new ArgumentException("Count of rows of the vector is not equal to count of columns of the matrix. "
                    + $"The size of vector = {vector.Size} and count of columns of the matrix = {ColumnsCount}.", nameof(vector));
            }

            Vector columnVector = new Vector(_rows.Length);

            for (int i = 0; i < _rows.Length; i++)
            {
                columnVector[i] = Vector.GetScalarProduct(_rows[i], vector);
            }

            return columnVector;
        }

        private static void CheckVectorSize(Vector vector, int vectorSize)
        {
            if (vector.Size != vectorSize)
            {
                throw new ArgumentException($"Argument \"{nameof(vector)}.{nameof(vector.Size)}\" = {vector.Size} is not the correct size. "
                    + $"Сorrect size = {vectorSize}.", nameof(vector));
            }
        }

        private static void CheckMatricesSizeEquality(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"The matrix has different sizes. The \"{nameof(matrix1)}\" = ({matrix1.RowsCount}x{matrix1.ColumnsCount}) "
                    + $"and the \"{matrix2}\" = ({matrix2.RowsCount}x{matrix2.ColumnsCount}).", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }
        }

        private static void CheckForNull<T>(T obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"The \"{typeof(T).Name}\" type argument is null.");
            }
        }

        private static void CheckIndex(int index, int maxRangeValue)
        {
            if (index < 0 || index >= maxRangeValue)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The argument \"{nameof(index)}\" = {index} is out of range. "
                    + $"Valid range is from 0 to {maxRangeValue - 1}.");
            }
        }

        public void Add(Matrix matrix)
        {
            CheckForNull(matrix);
            CheckMatricesSizeEquality(this, matrix);

            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i].Add(matrix._rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckForNull(matrix);
            CheckMatricesSizeEquality(this, matrix);

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
                    double commonMultiple = matrix[rowIndex][diagonalMatrixIndex] / matrix[diagonalMatrixIndex][diagonalMatrixIndex];

                    matrix[rowIndex] -= matrix[diagonalMatrixIndex] * commonMultiple;
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
            CheckForNull(matrix1);
            CheckForNull(matrix2);
            CheckMatricesSizeEquality(matrix1, matrix2);

            Matrix matricesSum = new Matrix(matrix1);

            matricesSum.Add(matrix2);

            return matricesSum;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            CheckForNull(matrix1);
            CheckForNull(matrix2);
            CheckMatricesSizeEquality(matrix1, matrix2);

            Matrix matricesDifference = new Matrix(matrix1);

            matricesDifference.Subtract(matrix2);

            return matricesDifference;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            CheckForNull(matrix1);
            CheckForNull(matrix2);

            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Count of rows of the \"{nameof(matrix1)}\" = {matrix1.ColumnsCount} is not equal to"
                    + $" count of columns of the \"{nameof(matrix2)}\" = {matrix2.RowsCount}.", $"{nameof(matrix1)}, {nameof(matrix2)}");
            }

            Matrix matricesProduct = new Matrix(matrix1.RowsCount, matrix2.ColumnsCount);

            for (int i = 0; i < matrix1.RowsCount; i++)
            {
                for (int j = 0; j < matrix2.ColumnsCount; j++)
                {
                    matricesProduct._rows[i][j] = Vector.GetScalarProduct(matrix1[i], matrix2.GetColumnVector(j));
                }
            }

            return matricesProduct;
        }

        public static Matrix operator *(Matrix matrix, double number)
        {
            CheckForNull(matrix);

            Matrix resultMatrix = new Matrix(matrix);

            resultMatrix.MultiplyByScalar(number);

            return resultMatrix;
        }

        public static Matrix operator *(double number, Matrix matrix)
        {
            CheckForNull(matrix);

            Matrix resultMatrix = new Matrix(matrix);

            resultMatrix.MultiplyByScalar(number);

            return resultMatrix;
        }

        public static Vector operator *(Matrix matrix, Vector vector)
        {
            CheckForNull(matrix);
            CheckForNull(vector);

            return matrix.GetProduct(vector);
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", (IEnumerable<Vector>)_rows)}}}";
        }
    }
}