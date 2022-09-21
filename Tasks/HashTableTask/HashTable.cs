using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Academits.Karetskas.HashTableTask
{
    public sealed class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] _table;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Argument out of range of table. Valid range is from 1 to {int.MaxValue}.");
            }

            _table = new List<T>[capacity];
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (_table[index] is not null)
            {
                _table[index].Add(item);
            }
            else
            {
                _table[index] = new List<T>(1);

                _table[index].Add(item);
            }

            Count++;
            modCount++;
        }

        private int GetIndex(T item)
        {
            if (item is null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % _table.Length);
        }

        public void Clear()
        {
            Array.Clear(_table);

            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (_table[index] is null || _table[index].Count == 0)
            {
                return false;
            }

            return _table[index].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), $"Argument \"{nameof(array)}\" is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("The length of array must be greate than 0.", nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"The \"{nameof(arrayIndex)}\" out of range of array. "
                    + $"Valid range from 0 to {array.Length - 1}");
            }

            if (array.Length - (arrayIndex + 1) > Count)
            {
                throw new ArgumentOutOfRangeException($"{nameof(array)} and {nameof(arrayIndex)}",
                    $"With the current parameters of the array length = {array.Length} and "
                    + $"array start index = {arrayIndex}, it is impossible to copy all the elements of the hash table. "
                    + $"Valid range from {Count} and {int.MaxValue}.");
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

            if (_table[index] is null || _table[index].Count == 0)
            {
                return false;
            }

            bool isRemovedItem = _table[index].Remove(item);

            if (isRemovedItem)
            {
                Count--;
                modCount++;
            }

            return isRemovedItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < _table.Length; i++)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException("The hash table has been modified during the iteration.");
                }

                if (_table[i] is null || _table[i].Count == 0)
                {
                    continue;
                }

                for (int j = 0; j < _table[i].Count; j++)
                {
                    yield return _table[i][j];
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

            for (int i = 0; i < _table.Length; i++)
            {
                if (_table[i] is null || _table[i].Count == 0)
                {
                    stringBuilder.Append("NULL")
                        .Append(", ");

                    continue;
                }

                stringBuilder.Append('[');

                for (int j = 0; j < _table[i].Count; j++)
                {
                    if (_table[i][j] is null)
                    {
                        stringBuilder.Append("NULL")
                            .Append(", ");

                        continue;
                    }

                    stringBuilder.Append(_table[i][j])
                        .Append(", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2)
                    .Append(']')
                    .Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }
    }
}