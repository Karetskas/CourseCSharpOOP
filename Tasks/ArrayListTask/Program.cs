using System;

namespace Academits.Karetskas.ArrayListTask
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
            ArrayList<string> additionResult = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Adding one element:", $"List before adding: {additionResult}.", PrintType.Write);
            Console.WriteLine();

            additionResult.Add("456");

            PrintToConsole(ConsoleColor.Yellow, "", $"List after adding: {additionResult}.");

            ArrayList<string> listToSetItem = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Changing the fourth element with an indexer.",
                $"List before change: {listToSetItem}.", PrintType.Write);
            Console.WriteLine();

            listToSetItem[3] = "000";

            PrintToConsole(ConsoleColor.Yellow, "", $"List after change: {listToSetItem}.");

            ArrayList<string> listToGetElement = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Reading the third element with an indexer.",
                $"List have elements: {listToGetElement}. Third element => {listToGetElement[2]}");

            ArrayList<string> clearingResult = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Clearing list:", $"List before clearing: {clearingResult}.", PrintType.Write);
            Console.WriteLine();

            clearingResult.Clear();

            PrintToConsole(ConsoleColor.Yellow, "", $"List after clearing: {clearingResult}.");

            ArrayList<string> list = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Check if an element exists and return its index:", $"Search list: {list}.", PrintType.Write);
            Console.WriteLine();

            PrintToConsole(ConsoleColor.Yellow, "", $"Does element \"16\" exist? {list.Contains("16")}. Index = {list.IndexOf("16")}.", PrintType.Write);
            Console.WriteLine();

            PrintToConsole(ConsoleColor.Yellow, "", $"Does element \"99\" exist? {list.Contains("99")}. Index = {list.IndexOf("99")}.");

            ArrayList<string> listToCopying = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Copying list to array:", $"List: {listToCopying}", PrintType.Write);
            Console.WriteLine();

            string[] stringsArray = new string[list.Count];

            list.CopyTo(stringsArray, 2);

            PrintToConsole(ConsoleColor.Yellow, "", $"Array: {string.Join(", ", stringsArray)}.");

            ArrayList<string> listForInsertingEtem = new ArrayList<string>(0);

            PrintToConsole(ConsoleColor.DarkYellow, "Insert item into the list:",
                $"List before change: {listForInsertingEtem}. Capacity = {listForInsertingEtem.Capacity}; Count = {listForInsertingEtem.Count}.", PrintType.Write);
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                listForInsertingEtem.Insert(i, Convert.ToString(i + 1));
            }

            listForInsertingEtem.Insert(3, "5");

            PrintToConsole(ConsoleColor.Yellow, "", $"List after change: {listForInsertingEtem}. " +
                $"Capacity = {listForInsertingEtem.Capacity}; Count = {listForInsertingEtem.Count}.");

            ArrayList<string> listToRemoveByIndex = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Deleting item that has index 3:", $"List before change: {listToRemoveByIndex}. " +
                $"Capacity = {listToRemoveByIndex.Capacity}; Count = {listToRemoveByIndex.Count}.", PrintType.Write);
            Console.WriteLine();

            listToRemoveByIndex.RemoveAt(3);

            PrintToConsole(ConsoleColor.Yellow, "", $"List after removal item: {listToRemoveByIndex}. " +
                $"Capacity = {listToRemoveByIndex.Capacity}; Count = {listToRemoveByIndex.Count}.");

            ArrayList<string> ListToRemoveByItem = GetItemsList();

            PrintToConsole(ConsoleColor.DarkYellow, "Deleting item that has number 16:", $"List before change: {ListToRemoveByItem}. " +
                $"Capacity = {ListToRemoveByItem.Capacity}; Count = {ListToRemoveByItem.Count}.", PrintType.Write);
            Console.WriteLine();

            ListToRemoveByItem.Remove("16");

            PrintToConsole(ConsoleColor.Yellow, "", $"List after removal item: {ListToRemoveByItem}. " +
                $"Capacity = {ListToRemoveByItem.Capacity}; Count = {ListToRemoveByItem.Count}.");

            ArrayList<string> listForTrimExcess = GetItemsList(11);

            PrintToConsole(ConsoleColor.DarkYellow, "Trim excess in the list:",
                $"List before change: {listForTrimExcess}. Capacity: {listForTrimExcess.Capacity}. Count: {listForTrimExcess.Count}.", PrintType.Write);
            Console.WriteLine();

            for (int i = 0; i < 2; i++)
            {
                listForTrimExcess.RemoveAt(listForTrimExcess.Count - 1);
            }

            listForTrimExcess.TrimExcess();

            PrintToConsole(ConsoleColor.Yellow, "", $"List after change: {listForTrimExcess}. " +
                $"Capacity: {listForTrimExcess.Capacity}. Count: {listForTrimExcess.Count}.");
        }

        private static ArrayList<string> GetItemsList(int itemsCount = 7)
        {
            if (itemsCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(itemsCount), $"The \"{nameof(itemsCount)}\" argument out of range of array. " +
                    $"Valid range from 0 to {int.MaxValue}.");
            }

            ArrayList<string> list = new ArrayList<string>(itemsCount);

            for (int i = 0; i < itemsCount; i++)
            {
                list.Add(Convert.ToString(i * i));
            }

            return list;
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