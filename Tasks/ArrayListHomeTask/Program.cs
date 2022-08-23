using System;
using System.IO;
using System.Collections.Generic;

namespace Academits.Karetskas.ArrayListHomeTask
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                List<int> list = GetElementsList();

                const string path = @"..\\..\\..\\List.txt";

                if (!WriteListToFile(path, list))
                {
                    Console.WriteLine("The path to the file is not specified or there is no data to write.");
                }
                else
                {
                    Console.WriteLine("List has been written to a file.");
                }

                File.Delete(path);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error has occurred: {e.Message}");
                Console.ResetColor();
            }

            try
            {
                const string path = @"..\\..\\..\\MyList.txt";

                List<int>? listFromFile = GetListFromFile(path);

                if (listFromFile is null)
                {
                    Console.WriteLine($"Read from file: List \"{nameof(listFromFile)}\" does not contain elements.");
                }
                else
                {
                    Console.WriteLine($"Read from file: {string.Join(", ", listFromFile)}. Capacity: {listFromFile.Capacity}. Count: {listFromFile.Count}");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error has occurred: {e.Message}");
                Console.ResetColor();
            }

            List<int> listFromRemoveEvenNumber = GetElementsList();

            RemoveEvenNumbers(listFromRemoveEvenNumber);

            Console.WriteLine($"List without even numbers: {string.Join(", ", listFromRemoveEvenNumber)}. " +
                $"Capacity: {listFromRemoveEvenNumber.Capacity}. Count: {listFromRemoveEvenNumber.Count}");

            List<int>? listWithoutDuplicateElements = GetListWithoutDuplicates(GetElementsList());

            if (listWithoutDuplicateElements is null)
            {
                return;
            }

            Console.WriteLine($"List without duplicates: {string.Join(", ", listWithoutDuplicateElements)}. "
                + $"Capacity: {listWithoutDuplicateElements.Capacity}. Count: {listWithoutDuplicateElements.Count}");
        }

        public static List<int> GetElementsList()
        {
            const int listLength = 10;

            List<int> list = new List<int>(listLength);

            for (int i = 0; i < listLength; i++)
            {
                list.Add(i);
                list.Add(i);
            }

            return list;
        }

        public static List<int>? GetListWithoutDuplicates(List<int> list)
        {
            if (list is null)
            {
                return null;
            }

            List<int> listWithoutDuplicateElements = new List<int>(list.Count);

            foreach (int number in list)
            {
                if (listWithoutDuplicateElements.Contains(number))
                {
                    listWithoutDuplicateElements.Add(number);
                }
            }

            return listWithoutDuplicateElements;
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            if (list is null)
            {
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);

                    i--;
                }
            }
        }

        public static bool WriteListToFile(string path, List<int> list)
        {
            if (string.IsNullOrEmpty(path) || list is null || list.Count == 0)
            {
                return false;
            }

            using StreamWriter writer = new StreamWriter(path);

            foreach (int item in list)
            {
                writer.WriteLine(item);
            }

            return true;
        }

        public static List<int> GetListFromFile(string path)
        {
            using StreamReader reader = new StreamReader(path);

            const int listLength = 10;

            List<int> list = new List<int>(listLength);

            while (reader.Peek() != -1)
            {
                int number = int.Parse(reader.ReadLine() ?? "");

                list.Add(number);
            }

            return list;
        }
    }
}