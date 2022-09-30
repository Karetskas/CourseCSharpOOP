using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Academits.Karetskas.HashTableTask
{
    public sealed class HashTable<T> : ICollection<T>
    {
        private const int _initialCapacity = 10;
        private readonly List<T>?[] _listsArray;
        private int _modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            _listsArray = new List<T>[_initialCapacity];
        }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Argument out of range of table. Valid range is greater than or equal to 1.");
            }

            _listsArray = new List<T>[capacity];
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (_listsArray[index] is null)
            {
                _listsArray[index] = new List<T>();
            }

            _listsArray[index]!.Add(item);

            Count++;
            _modCount++;
        }

        private int GetIndex(T item)
        {
            if (item is null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % _listsArray.Length);
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(_listsArray);

            Count = 0;
            _modCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            return _listsArray[index] is null ? false : _listsArray[index]!.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), $"Argument \"{nameof(array)}\" is null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"The \"{nameof(arrayIndex)}\" out of range of array. "
                    + "Valid range is greater than or equal to 0.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The number of elements in the HashTable is greater than the available space from arrayindex to"
                    + $"the end of the destination array.Valid range is greater than or equal to {Count}.", $"{nameof(array)}, {nameof(arrayIndex)}");
            }

            int index = arrayIndex;

            foreach (T item in this)
            {
                array[index] = item;

                index++;
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (_listsArray[index] is null || _listsArray[index]!.Count == 0)
            {
                return false;
            }

            bool isItemRemoved = _listsArray[index]!.Remove(item);

            if (isItemRemoved)
            {
                Count--;
                _modCount++;
            }

            return isItemRemoved;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = _modCount;

            foreach (List<T>? list in _listsArray)
            {
                if (list is null)
                {
                    continue;
                }

                foreach (T item in list)
                {
                    if (initialModCount != _modCount)
                    {
                        throw new InvalidOperationException("The hash table has been modified during the iteration.");
                    }

                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('[');

            foreach (List<T>? list in _listsArray)
            {
                if (list is null || list.Count == 0)
                {
                    stringBuilder.Append("NULL, ");

                    continue;
                }

                stringBuilder.Append('[');

                foreach (T item in list)
                {
                    if (item is null)
                    {
                        stringBuilder.Append("NULL, ");

                        continue;
                    }

                    stringBuilder.Append(item)
                        .Append(", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2)
                        .Append("], ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }
    }
}