using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Academits.Karetskas.ArrayListTask
{
    public sealed class ArrayList<T> : IList<T>
    {
        private const int InitialCapacity = 10;
        private T?[] items;
        private int modCount;

        public int Count { get; private set; }

        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"The argument \"{nameof(value)}\" = {value} is out of range of array. "
                        + $"Valid value must be greater than {Count}.");
                }

                if (value == items.Length)
                {
                    return;
                }

                Array.Resize(ref items, value);
            }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                CheckIndex(index, Count);

                return items[index]!;
            }

            set
            {
                CheckIndex(index, Count);

                items[index] = value;

                modCount++;
            }
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"The argument \"{nameof(capacity)}\" = {capacity} is out of range of array. "
                    + "Valid value must be greater than or equal 0.");
            }

            items = new T[capacity];
        }

        public ArrayList()
        {
            items = new T[InitialCapacity];
        }

        private static void CheckIndex(int index, int maxRangeValue)
        {
            if (index < 0 || index >= maxRangeValue)
            {
                if (maxRangeValue == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Any \"{nameof(index)}\" value is invalid because the arrayList is empty.");
                }

                throw new ArgumentOutOfRangeException(nameof(index), $"The argument \"{nameof(index)}\" = {index} is out of range of array. "
                    + $"Valid value is from 0 to {maxRangeValue}.");
            }
        }

        private void IncreaseCapacity()
        {
            if (items.Length == 0)
            {
                Capacity = InitialCapacity;

                return;
            }

            Capacity *= 2;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, Count);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"The argument \"{nameof(index)}\" = {index} is out of range of array. "
                    + $"Valid value is from 0 to {Count}.");
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            if (index < Count)
            {
                Array.Copy(items, index, items, index + 1, Count - index);
            }

            items[index] = item;

            Count++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index, Count);

            Array.Copy(items, index + 1, items, index, Count - (index + 1));

            items[Count - 1] = default;

            Count--;
            modCount++;
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(items, 0, Count);

            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), $"Argument \"{nameof(array)}\" is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("The array contains no elements.", nameof(array));
            }

            CheckIndex(arrayIndex, array.Length);

            Array.Copy(items, array, Count);
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
            double listFullness = (double)Count / items.Length * 100;

            if (listFullness < 90)
            {
                Capacity = Count;
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('[');

            foreach (T item in this)
            {
                if (item is null)
                {
                    stringBuilder.Append("null, ");

                    continue;
                }

                stringBuilder.Append(item)
                    .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2)
                .Append(']');

            return stringBuilder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (initialModCount != modCount)
                {
                    throw new InvalidOperationException("The list has been modified during the iteration.");
                }

                yield return items[i]!;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}