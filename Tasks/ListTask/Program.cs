using System;

namespace Academits.Karetskas.ListTask
{
    internal class Program
    {
        private enum PrintType
        {
            Write,
            WriteLine
        }

        static void Main()
        {
            SinglyLinkedList<int> linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.Green, "Print values from the list:", linkedList, PrintType.WriteLine);

            linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.Green, "Print value from the \"FirstItemData\" property of list",
                $"Current list: {linkedList}. The \"FirstItemData\" contains the following data: {linkedList.First}", PrintType.WriteLine);

            linkedList = new SinglyLinkedList<int>();
            PrintToConsole(ConsoleColor.Green, "Print count of values in an empty list",
                $"\"{nameof(linkedList)}\" contains {linkedList.Count} items.", PrintType.WriteLine);

            linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.Green, "Print count of values in the filled list",
                $"\"{nameof(linkedList)}\" contains {linkedList.Count} items.", PrintType.WriteLine);

            int firstItemData = linkedList.RemoveFirst();
            PrintToConsole(ConsoleColor.Green, "Print values from the list where first item is removed:",
                $"Current list: {linkedList}. Deleted data: {firstItemData}", PrintType.WriteLine);

            linkedList = GetItemsList();
            int thirdItemData = linkedList.RemoveAt(2);
            PrintToConsole(ConsoleColor.Green, "Print values from the list where third item is removed:",
                $"Current list: {linkedList}. Deleted data: {thirdItemData}", PrintType.WriteLine);

            linkedList = GetItemsList();
            int lastItemData = linkedList.RemoveAt(linkedList.Count - 1);
            PrintToConsole(ConsoleColor.Green, "Print values from the list where last item is removed:",
                $"Current list: {linkedList}. Deleted data: {lastItemData}", PrintType.WriteLine);

            linkedList = GetItemsList();
            bool isRemovedItem = linkedList.Remove(1);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"1\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = GetItemsList();
            isRemovedItem = linkedList.Remove(6);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"6\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = GetItemsList();
            isRemovedItem = linkedList.Remove(5);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"5\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(127);
            isRemovedItem = linkedList.Remove(127);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"127\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.Green, "Print values from the list:", "Items: ", PrintType.Write);

            for (int i = 0; i < linkedList.Count; i++)
            {
                PrintToConsole(ConsoleColor.Green, "", $"{i} = {linkedList.Get(i)}", PrintType.Write);

                if (i < linkedList.Count - 1)
                {
                    PrintToConsole(ConsoleColor.Green, "", ", ", PrintType.Write);
                }
            }

            PrintToConsole(ConsoleColor.Green, "", "", PrintType.WriteLine);

            linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.DarkYellow, "Changes in the list:", $"\"{nameof(linkedList)}\": {linkedList}.", PrintType.Write);
            PrintToConsole(ConsoleColor.Yellow, "", $"{Environment.NewLine}Previous value => New value: {Environment.NewLine}", PrintType.Write);

            for (int i = 0; i < linkedList.Count; i++)
            {
                PrintToConsole(ConsoleColor.Yellow, "", $"{linkedList.Set(i, i * i)} => {linkedList.Get(i)}", PrintType.Write);

                if (i < linkedList.Count - 1)
                {
                    PrintToConsole(ConsoleColor.Yellow, "", $";{Environment.NewLine}", PrintType.Write);
                }
            }

            PrintToConsole(ConsoleColor.Yellow, "", $".{Environment.NewLine}", PrintType.Write);
            PrintToConsole(ConsoleColor.Green, "", $"The List has been changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Adding first item to the list using the \"AddFirst\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.AddFirst(43);

            PrintToConsole(ConsoleColor.Yellow, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.DarkBlue, "Adding first item to the list using the \"Add\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Add(0, 34);

            PrintToConsole(ConsoleColor.Blue, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.DarkBlue, "Adding third item to the list using the \"Add\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Add(2, 69);

            PrintToConsole(ConsoleColor.Blue, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.DarkBlue, "Adding last item to the list using the \"Add\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Add(linkedList.Count - 1, 15);

            PrintToConsole(ConsoleColor.Blue, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.DarkGreen, "Reverse SinglyLinkedList:",
                $"\"{nameof(linkedList)}\" before the change: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Reverse();

            PrintToConsole(ConsoleColor.Green, "", $"\"{nameof(linkedList)}\" after the change: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList(10);
            PrintToConsole(ConsoleColor.DarkCyan, "Copy of linked list.", $"\"{nameof(linkedList)}\": {linkedList}.{Environment.NewLine}", PrintType.Write);

            SinglyLinkedList<int> linkedListCopy = linkedList.GetCopy();
            PrintToConsole(ConsoleColor.Cyan, "", $"\"{nameof(linkedListCopy)}\": {linkedListCopy}.", PrintType.WriteLine);
        }

        private static SinglyLinkedList<int> GetItemsList(int itemsCount = 5)
        {
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();

            for (int i = itemsCount; i > 0; i--)
            {
                linkedList.AddFirst(i);
            }

            return linkedList;
        }

        private static void PrintToConsole<T>(ConsoleColor color, string title, T? text, PrintType printType)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Console.WriteLine(title);
            }

            Console.ForegroundColor = color;

            if (printType == PrintType.Write)
            {
                Console.Write(text);

                Console.ResetColor();

                return;
            }

            Console.WriteLine(text);

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('-', 90));
            Console.ResetColor();
        }
    }
}