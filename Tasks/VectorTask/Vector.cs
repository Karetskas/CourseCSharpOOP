using System;

namespace Academits.Karetskas.VectorTask
{
    public sealed class Vector
    {
        public int Size { get; private set; }

        public double[] Components { get; private set; }

        public double Length
        {
            get
            {
                double componentsSquaredSum = 0;

                foreach (double component in Components)
                {
                    componentsSquaredSum += component * component;
                }

                return Math.Sqrt(componentsSquaredSum);
            }
        }

        public Vector(int size) : this(size, new double[1]) { }

        public Vector(double[] components) : this(1, components) { }

        public Vector(int size, double[] components)
        {
            if (components is null)
            {
                throw new ArgumentNullException(nameof(components), $"Argument of \"{nameof(components)}\" is null.");
            }

            if (components.Length == 0)
            {
                throw new ArgumentException($"Argument of \"{nameof(components)}\" has length = 0.", nameof(components));
            }

            if (size <= 0)
            {
                throw new ArgumentException($"Argument \"{nameof(size)}\" <= 0.", nameof(size));
            }

            if (components.Length > size)
            {
                Components = new double[components.Length];
                Size = components.Length;
            }
            else
            {
                Components = new double[size];
                Size = size;
            }

            components.CopyTo(Components, 0);
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            Size = vector.Size;

            Components = new double[vector.Components.Length];
            vector.Components.CopyTo(Components, 0);
        }

        public void Add(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            Vector resultAddition = this + vector;

            Size = resultAddition.Size;
            Components = resultAddition.Components;
        }

        public void Subtract(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            Vector resultSubtraction = this - vector;

            Size = resultSubtraction.Size;
            Components = resultSubtraction.Components;
        }

        public void MultiplyByScalar(double number)
        {
            Vector resultMultiplication = this * number;

            Components = resultMultiplication.Components;
        }

        public void Reverse()
        {
            Vector resultMultiplication = this * -1;

            Components = resultMultiplication.Components;
        }

        public void SetComponentValue(int index, double number)
        {
            if (index >= Components.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The \"{nameof(index)}\" argument is out of range of array.");
            }

            Components[index] = number;
        }

        public double GetComponentValue(int index)
        {
            if (index >= Components.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The \"{nameof(index)}\" argument is out of range of array.");
            }

            return Components[index];
        }

        public static Vector GetAdditionVectors(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Argument \"{nameof(vector1)}\" is null.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Argument \"{nameof(vector2)}\" is null.");
            }

            return vector1 + vector2;
        }

        public static Vector GetSubtractVectors(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Argument \"{nameof(vector1)}\" is null.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Argument \"{nameof(vector2)}\" is null.");
            }

            return vector1 - vector2;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Argument \"{nameof(vector1)}\" is null.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Argument \"{nameof(vector2)}\" is null.");
            }

            int minLengthArray = vector1.Components.Length < vector2.Components.Length ? vector1.Components.Length : vector2.Components.Length;
            double scalarProduct = 0;

            for (int i = 0; i < minLengthArray; i++)
            {
                scalarProduct += vector1.Components[i] * vector2.Components[i];
            }

            return scalarProduct;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Argument \"{nameof(vector1)}\" is null.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Argument \"{nameof(vector2)}\" is null.");
            }

            double[] arrayWithMaxLength = vector1.Components;
            double[] arrayWithMinLenght = vector2.Components;

            if (arrayWithMaxLength.Length < arrayWithMinLenght.Length)
            {
                arrayWithMaxLength = vector2.Components;
                arrayWithMinLenght = vector1.Components;
            }

            double[] arraysAdditionResult = new double[arrayWithMaxLength.Length];

            int index = 0;

            while (index < arrayWithMinLenght.Length)
            {
                arraysAdditionResult[index] = arrayWithMaxLength[index] + arrayWithMinLenght[index];

                index++;
            }

            Array.Copy(arrayWithMaxLength, index, arraysAdditionResult, index, arrayWithMaxLength.Length - index);

            return new Vector(arraysAdditionResult.Length, arraysAdditionResult);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), $"Argument \"{nameof(vector1)}\" is null.");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), $"Argument \"{nameof(vector2)}\" is null.");
            }

            bool isMaxLengthVector = true;
            double[] arrayWithMaxLenght = vector1.Components;

            if (vector1.Size < vector2.Size)
            {
                isMaxLengthVector = false;
                arrayWithMaxLenght = vector2.Components;
            }

            double[] arraysSubtractionResult = new double[arrayWithMaxLenght.Length];

            for (int i = 0; i < arrayWithMaxLenght.Length; i++)
            {
                if (isMaxLengthVector && i >= vector2.Size)
                {
                    Array.Copy(arrayWithMaxLenght, i, arraysSubtractionResult, i, arrayWithMaxLenght.Length - i);

                    break;
                }

                arraysSubtractionResult[i] = i < vector1.Size ? vector1.Components[i] - vector2.Components[i] : 0 - vector2.Components[i];
            }

            return new Vector(arraysSubtractionResult.Length, arraysSubtractionResult);
        }

        public static Vector operator *(Vector vector, double number)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            double[] multiplyingResult = GetArrayMultiplyiedByNumber(vector.Components, number);

            return new Vector(multiplyingResult.Length, multiplyingResult);
        }

        public static Vector operator *(double number, Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), $"Argument \"{nameof(vector)}\" is null.");
            }

            double[] multiplyingResult = GetArrayMultiplyiedByNumber(vector.Components, number);

            return new Vector(multiplyingResult.Length, multiplyingResult);
        }

        private static double[] GetArrayMultiplyiedByNumber(double[] array, double number)
        {
            double[] multiplyingResult = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                multiplyingResult[i] = array[i] * number;
            }

            return multiplyingResult;
        }

        public override string ToString()
        {
            return $"{{ {string.Join(", ", Components)} }}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (vector.Size != Size || Components.Length != vector.Components.Length)
            {
                return false;
            }

            for (int i = 0; i < Components.Length; i++)
            {
                if (Components[i] != vector.Components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int hash = 1;

            hash = prime * hash + Size;

            foreach (double component in Components)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }
    }
}
