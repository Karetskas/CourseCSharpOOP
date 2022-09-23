using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Academits.Karetskas.ListTask
{
    internal sealed class SinglyLinkedList<T> : IEnumerable<T>
    {
        private int modCount;
        private ListItem<T>? head;

        public int Count { get; private set; }

        public T? First
        {
            get
            {
                CheckListExistence();

                return head!.Data;
            }
        }

        private ListItem<T> GetIndex(int index)
        {
            ListItem<T>? listItem = head;

            for (int i = 0; i != index; i++)
            {
                listItem = listItem!.Next;
            }

            return listItem!;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                if (Count == 0)
                {
                    throw new ArgumentException($"Any \"{nameof(index)}\" value is invalid because the list is empty.", nameof(index));
                }

                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". "
                    + $"Valid range is from 0 to {Count - 1}.");
            }
        }

        private void CheckListExistence()
        {
            if (head is null)
            {
                throw new InvalidOperationException($"SinglyLinkedList<{typeof(T).Name}> has no items.");
            }
        }

        public T? Get(int index)
        {
            CheckIndex(index);

            ListItem<T>? listItem = GetIndex(index);

            return listItem.Data;
        }

        public T? Set(int index, T? data)
        {
            CheckIndex(index);

            ListItem<T>? listItem = GetIndex(index);

            T? oldData = listItem.Data;
            listItem.Data = data;

            modCount++;

            return oldData;
        }

        public void AddFirst(T? data)
        {
            ListItem<T> newItem = new ListItem<T>(data);

            if (head is null)
            {
                head = newItem;
            }
            else
            {
                newItem.Next = head;
                head = newItem;
            }

            Count++;
            modCount++;
        }

        public void Add(int index, T? data)
        {
            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            if (index != Count)
            {
                CheckIndex(index);
            }

            ListItem<T> newItem = new ListItem<T>(data);
            ListItem<T>? previousItem = GetIndex(index - 1);

            newItem.Next = previousItem.Next;
            previousItem.Next = newItem;

            Count++;
            modCount++;
        }

        public T? RemoveFirst()
        {
            CheckListExistence();

            T? data = head!.Data;
            head = head.Next;

            Count--;
            modCount++;

            return data;
        }

        public T? RemoveAt(int index)
        {
            if (index == 0)
            {
                return RemoveFirst();
            }

            CheckIndex(index);

            ListItem<T>? previousItem = GetIndex(index - 1);

            T? data = previousItem.Next!.Data;
            previousItem.Next = previousItem.Next.Next;

            Count--;
            modCount++;

            return data;
        }

        public bool Remove(T data)
        {
            ListItem<T>? previousItem = null;

            for (ListItem<T>? listItem = head; listItem is not null; listItem = listItem.Next)
            {
                if (Equals(listItem.Data, data))
                {
                    if (previousItem is null)
                    {
                        head = head!.Next;
                    }
                    else
                    {
                        previousItem.Next = previousItem.Next!.Next;
                    }

                    Count--;
                    modCount++;

                    return true;
                }

                previousItem = listItem;
            }

            return false;
        }

        public void Reverse()
        {
            if (head is null || Count == 1)
            {
                return;
            }

            ListItem<T>? previousItem = null;
            ListItem<T>? nextItem;

            for (ListItem<T>? currentItem = head; currentItem is not null; currentItem = nextItem)
            {
                nextItem = currentItem.Next;
                currentItem.Next = previousItem;
                previousItem = currentItem;
            }

            head = previousItem;

            modCount++;
        }

        public override string ToString()
        {
            if (head is null)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder(Count);

            stringBuilder.Append('[');

            foreach (T? data in this)
            {
                if (data is null)
                {
                    stringBuilder.Append("NULL, ");

                    continue;
                }

                stringBuilder.Append(data)
                    .Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> linkedListClone = new SinglyLinkedList<T>();

            if (head is null)
            {
                return linkedListClone;
            }

            ListItem<T> previousItem = new ListItem<T>(head.Data);

            linkedListClone.head = previousItem;

            for (ListItem<T>? listItem = head.Next; listItem is not null; listItem = listItem.Next)
            {
                previousItem.Next = new ListItem<T>(listItem.Data);

                previousItem = previousItem.Next;
            }

            linkedListClone.Count = Count;

            return linkedListClone;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int itemsCurrentCount = modCount;

            for (ListItem<T>? listItem = head; listItem is not null; listItem = listItem.Next)
            {
                if (itemsCurrentCount != modCount)
                {
                    throw new InvalidOperationException("The list has been modified during the iteration.");
                }

                yield return listItem.Data!;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}