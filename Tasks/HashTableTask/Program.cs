using System;

namespace Academits.Karetskas.HashTableTask
{
    internal class Program
    {
        enum PrintType
        {
            Write = 0,
            WriteLine = 1
        }

        static void Main()
        {
            HashTable<string> hashTableToAddingItems = new HashTable<string>(10);

            hashTableToAddingItems.Add("11");
            hashTableToAddingItems.Add("22");
            hashTableToAddingItems.Add("33");
            hashTableToAddingItems.Add("44");
            hashTableToAddingItems.Add("55");
            hashTableToAddingItems.Add("66");
            hashTableToAddingItems.Add("77");
            hashTableToAddingItems.Add("88");
            hashTableToAddingItems.Add("99");
            hashTableToAddingItems.Add("100");

            PrintToConsole(ConsoleColor.DarkYellow, "Adding items to the hash table:", $"Hash table: {hashTableToAddingItems}.", PrintType.Write);
            Console.WriteLine();

            PrintToConsole(ConsoleColor.Yellow, "", $"Hash table has {hashTableToAddingItems.Count} items.");

            HashTable<string> hashTableForClearing = new HashTable<string>(3);

            hashTableForClearing.Add("Hello");
            hashTableForClearing.Add("world");
            hashTableForClearing.Add("!");

            PrintToConsole(ConsoleColor.DarkYellow, "Clearing items for the hash table:",
                $"Hash table before clearing: {hashTableForClearing}. Count items: {hashTableForClearing.Count}", PrintType.Write);
            Console.WriteLine();

            hashTableForClearing.Clear();

            PrintToConsole(ConsoleColor.Yellow, "", $"Hash table after clearing: {hashTableForClearing}. Count items: {hashTableForClearing.Count}.");

            HashTable<int> hashTableForSearch = new HashTable<int>(3);

            hashTableForSearch.Add(444);
            hashTableForSearch.Add(555);
            hashTableForSearch.Add(666);

            PrintToConsole(ConsoleColor.DarkYellow, "Check whether the hash table contains the numbers \"555\" and \"999\".",
                $"Number \"555\" - {hashTableForSearch.Contains(555)}. Number \"999\" - {hashTableForSearch.Contains(999)}.");

            HashTable<string> hashTableToArray = new HashTable<string>(3);

            hashTableToArray.Add("H4el");
            hashTableToArray.Add("wo3r8");
            hashTableToArray.Add("!!!!!");

            PrintToConsole(ConsoleColor.DarkYellow, "Copying hash table to array:", $"Hash table: {hashTableToArray}.", PrintType.Write);
            Console.WriteLine();

            string[] array = new string[hashTableToArray.Count];

            hashTableToArray.CopyTo(array, 0);

            PrintToConsole(ConsoleColor.Yellow, "", $"Array: [{string.Join(", ", array)}].");

            HashTable<int> hashTableForDeletingItems = new HashTable<int>(4);

            hashTableForDeletingItems.Add(111);
            hashTableForDeletingItems.Add(222);
            hashTableForDeletingItems.Add(333);
            hashTableForDeletingItems.Add(444);

            PrintToConsole(ConsoleColor.DarkYellow, "Deleting items for hash table:", $"Hash table before deleting items: {hashTableForDeletingItems}.", PrintType.Write);
            Console.WriteLine();

            hashTableForDeletingItems.Remove(222);
            hashTableForDeletingItems.Remove(333);
            hashTableForDeletingItems.Remove(111);

            PrintToConsole(ConsoleColor.Yellow, "", $"Hash table after deleting items: {hashTableForDeletingItems}.");
        }

        private static void PrintToConsole<T>(ConsoleColor color, string title, T? text, PrintType printType = PrintType.WriteLine)
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