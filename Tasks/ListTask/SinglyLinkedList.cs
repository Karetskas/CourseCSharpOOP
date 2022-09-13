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

        public T? First => Get(0);

        private ListItem<T>? GetAt(int index)
        {
            ListItem<T>? listItem = head;

            for (int currentIndex = 0; currentIndex < Count; currentIndex++, listItem = listItem!.Next)
            {
                if (currentIndex == index)
                {
                    break;
                }
            }

            return listItem;
        }

        public T? Get(int index)
        {
            if (head is null)
            {
                throw new InvalidOperationException("SinglyLinkedList<T> has no items.");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". " +
                    $"Valid range is from 0 to {Count - 1}.");
            }

            ListItem<T>? listItem = GetAt(index);

            return listItem!.Data;
        }

        public T? Set(int index, T? data)
        {
            if (head is null)
            {
                throw new InvalidOperationException("SinglyLinkedList<T> has no items.");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". " +
                    $"Valid range is from 0 to {Count - 1}.");
            }

            ListItem<T>? listItem = GetAt(index);

            T? previousValue = listItem!.Data;
            listItem.Data = data;

            modCount++;

            return previousValue;
        }

        public void AddFirst(T? data)
        {
            Add(0, data);
        }

        public void Add(int index, T? data)
        {
            ListItem<T> newItem = new ListItem<T>(data);

            if (index == 0)
            {
                newItem.Next = head;
                head = newItem;
            }
            else
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". " +
                        $"Valid range is from 0 to {Count - 1}.");
                }

                ListItem<T>? listItem = GetAt(index - 1);

                newItem.Next = listItem!.Next;
                listItem.Next = newItem;
            }

            Count++;
            modCount++;
        }

        public T? RemoveFirst()
        {
            return RemoveAt(0);
        }

        public T? RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". " +
                    $"Valid range is from 0 to {Count - 1}.");
            }

            T? data;

            if (index == 0)
            {
                if (head is null)
                {
                    return default;
                }

                data = head.Data;
                head = head.Next;
            }
            else
            {
                ListItem<T>? previousItem = GetAt(index - 1);

                data = previousItem!.Next!.Data;
                previousItem.Next = previousItem.Next.Next;
            }

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
            if (head is null)
            {
                throw new InvalidOperationException("SinglyLinkedList<T> has no items.");
            }

            if (Count == 1 || IsSymmetric())
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

        private bool IsSymmetric()
        {
            SinglyLinkedList<T> linkedListClone = new SinglyLinkedList<T>();
            ListItem<T>? listItemclone = null;

            bool isEvenItemCount = Count % 2 == 0;
            int listMiddle = Count / 2;
            int index = 0;

            for (ListItem<T>? listItem = head; index < Count; index++, listItem = listItem!.Next)
            {
                if (index < listMiddle)
                {
                    linkedListClone.AddFirst(listItem!.Data);

                    continue;
                }

                if (index == listMiddle)
                {
                    listItemclone = linkedListClone.head!;

                    if (!isEvenItemCount)
                    {
                        index++;
                        listItem = listItem!.Next;
                    }
                }

                if (!Equals(listItem!.Data, listItemclone!.Data))
                {
                    return false;
                }

                listItemclone = listItemclone.Next;
            }

            return true;
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
                    stringBuilder.Append("NULL")
                        .Append(", ");

                    continue;
                }

                stringBuilder.Append(data)
                    .Append(", ");
            }

            if (stringBuilder.Length > 2)
            {
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            }

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