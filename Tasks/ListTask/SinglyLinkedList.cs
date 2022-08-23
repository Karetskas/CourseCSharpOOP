using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Academits.Karetskas.ListTask
{
    internal sealed class SinglyLinkedList<T> : IEnumerable<T>
    {
        private int count;
        private static int modCount;
        private ListItem<T>? head;

        public ListItem<T>? Head
        {
            get => head;

            set
            {
                if (value is null)
                {
                    count = 0;
                }

                head = value;
            }
        }

        public int Count => count;

        public T? FirstItemData => GetData(0);

        private ListItem<T> GetItem(int index)
        {
            if (head is null)
            {
                throw new ArgumentNullException($"{nameof(head)}", $"SinglyLinkedList<T> has no items.");
            }

            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Argument \"{nameof(index)}\" out of range \"ListTask\". " +
                    $"Valid range is from 0 to {count - 1}}}.");
            }

            int itemsNumber = 0;

            for (ListItem<T>? listItem = head; listItem is not null; listItem = listItem.Next)
            {
                if (itemsNumber == index)
                {
                    return listItem;
                }

                itemsNumber++;
            }

            throw new ArgumentException($"The \"{nameof(count)}\" = {count} property does not correspond to the number of items which is {index}.");
        }

        public T? GetData(int index)
        {
            return GetItem(index).Data;
        }

        public T? SetData(int index, T? data)
        {
            ListItem<T> listItem = GetItem(index);

            T? previousValue = listItem.Data;
            listItem.Data = data;

            return previousValue;
        }

        public void AddFirst(ListItem<T> item)
        {
            Add(0, item);
        }

        public void Add(int index, ListItem<T> item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), $"Argument \"{nameof(item)}\" is null.");
            }

            if (index == 0)
            {
                item.Next = head;
                Head = item;
            }
            else
            {
                ListItem<T> listItem = GetItem(index - 1);

                item.Next = listItem.Next;
                listItem.Next = item;
            }

            count++;
            modCount++;
        }

        public T? RemoveFirst()
        {
            return RemoveItem(0);
        }

        public T? RemoveItem(int index)
        {
            T? data;

            if (index == 0)
            {
                if (head is null)
                {
                    return default;
                }

                data = head.Data;
                Head = head.Next;
            }
            else
            {
                ListItem<T> previousItem = GetItem(index - 1);

                data = previousItem.Next!.Data;
                previousItem.Next = previousItem.Next.Next;
            }

            count--;
            modCount++;

            return data;
        }

        public bool IsRemoveItem(T data)
        {
            ListItem<T>? previousItem = null;

            for (ListItem<T>? listItem = head; listItem is not null; listItem = listItem.Next)
            {
                if (Equals(listItem.Data, data))
                {
                    if (previousItem is null)
                    {
                        Head = head!.Next;
                    }
                    else
                    {
                        previousItem.Next = previousItem.Next!.Next;
                    }

                    count--;
                    modCount++;

                    return true;
                }

                previousItem = listItem;
            }

            return false;
        }

        public static void Reverse(SinglyLinkedList<T> linkedList)
        {
            if (linkedList is null)
            {
                throw new ArgumentNullException($"{nameof(linkedList)}", $"Argument \"{nameof(linkedList)}\" is null.");
            }

            ListItem<T>? previousItem = null;
            ListItem<T>? nextItem;

            for (ListItem<T>? currentItem = linkedList.head; currentItem is not null; currentItem = nextItem)
            {
                nextItem = currentItem.Next;
                currentItem.Next = previousItem;
                previousItem = currentItem;
            }

            linkedList.Head = previousItem;

            modCount++;
        }

        public override string ToString()
        {
            if (head is null)
            {
                return "LIST EMPTY";
            }

            StringBuilder text = new StringBuilder(count);

            foreach (T? data in this)
            {
                if (data is null)
                {
                    text.Append("NULL")
                        .Append(", ");

                    continue;
                }

                if ((data.GetType() == typeof(string) || data.GetType() == typeof(StringBuilder)) && data.ToString() == "")
                {
                    text.Append("EMPTY")
                        .Append(", ");

                    continue;
                }

                text.Append(data.ToString())
                    .Append(", ");
            }

            if (text.Length > 0)
            {
                text.Remove(text.Length - 2, 2);
            }

            return text.ToString();
        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> linkedListClone = new SinglyLinkedList<T>();

            if (head is null)
            {
                linkedListClone.head = null;

                return linkedListClone;
            }

            ListItem<T> previousItem = new ListItem<T>(default, null);

            linkedListClone.Head = previousItem;

            for (ListItem<T>? listItem = head; listItem is not null; listItem = listItem.Next)
            {
                previousItem.Data = listItem.Data;

                if (listItem.Next is null)
                {
                    previousItem.Next = null;
                    break;
                }

                ListItem<T> emptyListItem = new ListItem<T>(default, null);

                previousItem.Next = emptyListItem;
                previousItem = emptyListItem;
            }

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