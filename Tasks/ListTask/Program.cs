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
            ListItem<int> emptyListItemForInteger = new ListItem<int>();
            PrintToConsole(ConsoleColor.Green, "ListItem<int>()", emptyListItemForInteger, PrintType.WriteLine);

            ListItem<int> listItemForIntegerWithLink = new ListItem<int>(new ListItem<int>(12345, null));
            PrintToConsole(ConsoleColor.Green, "ListItem<int>(Reference)", listItemForIntegerWithLink, PrintType.WriteLine);

            ListItem<int> listItemForIntegerWithData = new ListItem<int>(123);
            PrintToConsole(ConsoleColor.Green, "ListItem<int>(Data)", listItemForIntegerWithData, PrintType.WriteLine);

            ListItem<int> listItemForIntegerWithDataAndLink = new ListItem<int>(789, new ListItem<int>(12345, null));
            PrintToConsole(ConsoleColor.Green, "ListItem<int>(Data, Reference)", listItemForIntegerWithDataAndLink, PrintType.WriteLine);

            ListItem<string> emptyListItemForString = new ListItem<string>();
            PrintToConsole(ConsoleColor.Green, "ListItem<string>()", emptyListItemForString, PrintType.WriteLine);

            ListItem<string> listItemForStringWithLink = new ListItem<string>(new ListItem<string>("test1", null));
            PrintToConsole(ConsoleColor.Green, "ListItem<string>(Reference)", listItemForStringWithLink, PrintType.WriteLine);

            ListItem<string> listItemForStringWithData = new ListItem<string>("test2");
            PrintToConsole(ConsoleColor.Green, "ListItem<string>(Data)", listItemForStringWithData, PrintType.WriteLine);

            ListItem<string> listItemForStringWithDataAndLink = new ListItem<string>("test3", new ListItem<string>("test4", null));
            PrintToConsole(ConsoleColor.Green, "ListItem<string>(Data, Reference)", listItemForStringWithDataAndLink, PrintType.WriteLine);

            SinglyLinkedList<int> linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.Green, "Print values from the list:", linkedList, PrintType.WriteLine);

            linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.Green, "Print value from the \"Head\" of list",
                $"Current list: {linkedList}. The \"Head\" contains the following data: {linkedList.Head}", PrintType.WriteLine);

            linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.Green, "Print value from the \"FirstItemData\" property of list",
                $"Current list: {linkedList}. The \"FirstItemData\" contains the following data: {linkedList.FirstItemData}", PrintType.WriteLine);

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
            int thirdItemData = linkedList.RemoveItem(2);
            PrintToConsole(ConsoleColor.Green, "Print values from the list where third item is removed:",
                $"Current list: {linkedList}. Deleted data: {thirdItemData}", PrintType.WriteLine);

            linkedList = GetItemsList();
            int lastItemData = linkedList.RemoveItem(linkedList.Count - 1);
            PrintToConsole(ConsoleColor.Green, "Print values from the list where last item is removed:",
                $"Current list: {linkedList}. Deleted data: {lastItemData}", PrintType.WriteLine);

            linkedList = GetItemsList();
            bool isRemovedItem = linkedList.IsRemoveItem(1);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"1\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = GetItemsList();
            isRemovedItem = linkedList.IsRemoveItem(6);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"6\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = GetItemsList();
            isRemovedItem = linkedList.IsRemoveItem(5);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"5\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(new ListItem<int>(4, null));
            isRemovedItem = linkedList.IsRemoveItem(4);
            PrintToConsole(ConsoleColor.Green, "Print of the result of deleting an item that has the value \"4\" in the \"isRemoveItem\" function:",
                $"Current list: {linkedList}. Has the item been removed?: {isRemovedItem}", PrintType.WriteLine);

            linkedList = GetItemsList();

            PrintToConsole(ConsoleColor.Green, "Print values from the list:", "Items: ", PrintType.Write);

            for (int i = 0; i < linkedList.Count; i++)
            {
                PrintToConsole(ConsoleColor.Green, "", $"{i} = {linkedList.GetData(i)}", PrintType.Write);

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
                PrintToConsole(ConsoleColor.Yellow, "", $"{linkedList.SetData(i, i * i)} => {linkedList.GetData(i)}", PrintType.Write);

                if (i < linkedList.Count - 1)
                {
                    PrintToConsole(ConsoleColor.Yellow, "", $";{Environment.NewLine}", PrintType.Write);
                }
            }

            PrintToConsole(ConsoleColor.Yellow, "", $".{Environment.NewLine}", PrintType.Write);
            PrintToConsole(ConsoleColor.Green, "", $"The List has been changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();
            ListItem<int> addedItem = new ListItem<int>(123);

            PrintToConsole(ConsoleColor.DarkYellow, "Adding first item to the list using the \"AddFirst\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.AddFirst(addedItem);

            PrintToConsole(ConsoleColor.Yellow, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();
            addedItem = new ListItem<int>(11111);

            PrintToConsole(ConsoleColor.DarkBlue, "Adding first item to the list using the \"Add\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Add(0, addedItem);

            PrintToConsole(ConsoleColor.Blue, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();
            addedItem = new ListItem<int>(33333);

            PrintToConsole(ConsoleColor.DarkBlue, "Adding third item to the list using the \"Add\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Add(2, addedItem);

            PrintToConsole(ConsoleColor.Blue, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();
            addedItem = new ListItem<int>(55555);

            PrintToConsole(ConsoleColor.DarkBlue, "Adding last item to the list using the \"Add\" function:",
                $"\"{nameof(linkedList)}\" before the changed: {linkedList}.{Environment.NewLine}", PrintType.Write);

            linkedList.Add(linkedList.Count - 1, addedItem);

            PrintToConsole(ConsoleColor.Blue, "", $"\"{nameof(linkedList)}\" after the changed: {linkedList}.", PrintType.WriteLine);

            linkedList = GetItemsList();
            PrintToConsole(ConsoleColor.DarkGreen, "Reverse SinglyLinkedList:",
                $"\"{nameof(linkedList)}\" before the change: {linkedList}.{Environment.NewLine}", PrintType.Write);

            SinglyLinkedList<int>.Reverse(linkedList);

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
                linkedList.AddFirst(new ListItem<int>(i, null));
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