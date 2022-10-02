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
                CheckThatListEmpty();

                return head!.Data;
            }
        }

        private ListItem<T> GetItem(int index)
        {
            ListItem<T>? listItem = head;

            for (int i = 0; i < index; i++)
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
                    throw new ArgumentOutOfRangeException(nameof(index), $"Any \"{nameof(index)}\" value is invalid because the list is empty.");
                }

                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". "
                    + $"Valid range is from 0 to {Count - 1}.");
            }
        }

        private void CheckThatListEmpty()
        {
            if (head is null)
            {
                throw new InvalidOperationException($"SinglyLinkedList<{typeof(T).Name}> has no items.");
            }
        }

        public T? Get(int index)
        {
            CheckIndex(index);

            return GetItem(index).Data;
        }

        public T? Set(int index, T? data)
        {
            CheckIndex(index);

            ListItem<T> listItem = GetItem(index);

            T? oldData = listItem.Data;
            listItem.Data = data;

            modCount++;

            return oldData;
        }

        public void AddFirst(T? data)
        {
            head = new ListItem<T>(data, head);

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

            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". "
                    + $"Valid range is from 0 to {Count}.");
            }

            ListItem<T> previousItem = GetItem(index - 1);

            previousItem.Next = new ListItem<T>(data, previousItem.Next);

            Count++;
            modCount++;
        }

        public T? RemoveFirst()
        {
            CheckThatListEmpty();

            T? data = head!.Data;
            head = head.Next;

            Count--;
            modCount++;

            return data;
        }

        public T? RemoveAt(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousItem = GetItem(index - 1);

            T? data = previousItem.Next!.Data;
            previousItem.Next = previousItem.Next.Next;

            Count--;
            modCount++;

            return data;
        }

        public bool Remove(T data)
        {
            for (ListItem<T>? currentItem = head, previousItem = null; currentItem is not null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (Equals(currentItem.Data, data))
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
            }

            return false;
        }

        public void Reverse()
        {
            if (Count < 2)
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

            for (ListItem<T>? currentItem = head.Next; currentItem is not null; currentItem = currentItem.Next)
            {
                previousItem.Next = new ListItem<T>(currentItem.Data);

                previousItem = previousItem.Next;
            }

            linkedListClone.Count = Count;

            return linkedListClone;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (ListItem<T>? listItem = head; listItem is not null; listItem = listItem.Next)
            {
                if (currentModCount != modCount)
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