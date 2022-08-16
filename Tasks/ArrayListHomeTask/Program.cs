using System;
using System.IO;
using System.Collections.Generic;

namespace Academits.Karetskas.ArrayListHomeTask
{
    internal class Program
    {
        static void Main()
        {
            const int listLength = 10;

            List<int> list = new List<int>(listLength);
            
            for (int i = 0; i < listLength; i++)
            {
                list.Add(i);
            }

            list.Add(3);
            list.Add(3);
            list.Add(7);
            list.Add(4);

            try
            {
                const string path = @"..\\..\\..\\List.txt";

                if (!WriteListToFile(path, list))
                {
                    Console.WriteLine("The path to the file is not specified or there is no data to write.");
                }

                List<int>? listFromFile = ReadFileToList(path);

                Console.WriteLine($"Read from file: {string.Join(", ", list)}. Capasity: {list.Capacity}. Count: {list.Count}");

                RemoveEvenNumbersFromList(list);

                Console.WriteLine($"List without even numbers: {string.Join(", ", list)}. Capasity: {list.Capacity}. Count: {list.Count}");

                List<int>? listWithoutDublicateElements = RemoveAllDublicateElements(list);

                if(listWithoutDublicateElements is null)
                {
                    return;
                }

                Console.WriteLine($"List without dublicates: {string.Join(", ", listWithoutDublicateElements)}. " 
                    + $"Capasity: {listWithoutDublicateElements.Capacity}. Count: {listWithoutDublicateElements.Count}");

                File.Delete(path);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error has occurred: {e.Message}");
                Console.ResetColor();
            }
        }

        public static List<int>? RemoveAllDublicateElements(List<int> list)
        {
            if(list is null)
            {
                return null;
            }

            List<int> listWithoutDublicateElements = new List<int>(list.Capacity);

            foreach (int number in list)
            {
                if(listWithoutDublicateElements.IndexOf(number, 0) == -1)
                {
                    listWithoutDublicateElements.Add(number);
                }
            }

            listWithoutDublicateElements.TrimExcess();

            return listWithoutDublicateElements;
        }

        public static void RemoveEvenNumbersFromList(List<int> list)
        {
            if(list is null)
            {
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.Remove(list[i]);
                }
            }

            list.TrimExcess();
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

        public static List<int> ReadFileToList(string path)
        {
            using StreamReader reader = new StreamReader(path);

            const int listLength = 10;

            List<int> list = new List<int>(listLength);

            while(reader.Peek() != -1)
            {
                int number;

                if(!int.TryParse(reader.ReadLine(), out number))
                {
                    throw new ArgumentException("The data in the file is not an integer.", nameof(number));
                }
                
                list.Add(number);
            }

            return list;
        }
    }
}