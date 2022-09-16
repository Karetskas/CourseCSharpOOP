using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Academits.Karetskas.ArrayListTask
{
    public sealed class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int length;
        private int modCount;

        public int Count => length;

        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < length)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"The \"{nameof(value)}\" argument out of range of array. " +
                        $"Valid range from {length} to {int.MaxValue}.");
                }

                if (value == items.Length)
                {
                    return;
                }

                T[] oldArray = items;

                items = new T[value];

                Array.Copy(oldArray, 0, items, 0, length);

                modCount++;
            }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (length == 0)
                {
                    throw new InvalidOperationException("There are no items in the list.");
                }

                if (index < 0 || index >= length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"The \"{nameof(index)}\" argument out of range of array. " +
                        $"Valid range from 0 to {length - 1}.");
                }

                return items[index];
            }

            set
            {
                if (length == 0)
                {
                    throw new InvalidOperationException("There are no items in the list.");
                }

                if (index < 0 || index >= length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"The \"{nameof(index)}\" argument out of range of array. " +
                        $"Valid range from 0 to {length - 1}.");
                }

                items[index] = value;

                modCount++;
            }
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"The \"{nameof(capacity)}\" argument out of range of array. " +
                    $"Valid range from 0 to {int.MaxValue}.");
            }

            items = new T[capacity];
        }

        private void IncreaseCapacity()
        {
            if (items.Length == 0)
            {
                items = new T[1];

                return;
            }

            T[] oldArray = items;

            items = length >= int.MaxValue / 2 ? new T[int.MaxValue]
                                               : new T[length * 2];

            Array.Copy(oldArray, 0, items, 0, length);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, length);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > length || length == int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The \"{nameof(index)}\" argument out of range of array. " +
                    $"Valid range from 0 to {length}.");
            }

            if (index == items.Length)
            {
                Add(item);

                return;
            }

            if (length + 1 > items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, length - index);

            items[index] = item;

            length++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            if (length == 0)
            {
                throw new InvalidOperationException("There are no items in the list.");
            }

            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The \"{nameof(index)}\" argument out of range of array. " +
                    $"Valid range from 0 to {length - 1}.");
            }

            Array.Copy(items, index + 1, items, index, length - (index + 1));

            length--;
            modCount++;
        }

        public void Add(T item)
        {
            if (length == int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(length), $"The \"{nameof(length)}\" argument out of range of array. " +
                    $"Valid range from 0 to {length}.");
            }

            if (length == items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = item;

            length++;
            modCount++;
        }

        public void Clear()
        {
            length = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(item, items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), $"Argument \"{nameof(array)}\" is null.");
            }

            if (length == 0)
            {
                throw new InvalidOperationException("There are no items in the list.");
            }

            if (arrayIndex < 0 || arrayIndex >= length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"The \"{nameof(arrayIndex)}\" argument out of range of array. " +
                    $"Valid range from 0 to {length - 1}.");
            }

            Array.Copy(items, arrayIndex, array, 0, length - arrayIndex);
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            RemoveAt(itemIndex);

            return true;
        }

        public void TrimExcess()
        {
            const double epsilon = 1.0e-10;

            double listFullness = (double)length / items.Length * 100;

            if (90 - listFullness > -epsilon)
            {
                Array.Resize(ref items, length);
            }
        }

        public override string ToString()
        {
            if (length == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('[');

            foreach (T item in this)
            {
                if (item is null)
                {
                    stringBuilder.Append("null")
                        .Append(", ");

                    continue;
                }

                stringBuilder.Append(item.ToString())
                    .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2)
                .Append(']');

            return stringBuilder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < length; i++)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException("The list has been modified during the iteration.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}