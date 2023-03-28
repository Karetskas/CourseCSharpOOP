using System;
using System.Linq;
using System.Collections.Generic;

namespace Academits.Karetskas.LambdasTask
{
    internal class Program
    {
        static void Main()
        {
            var peopleList = GetPeopleList();

            Console.WriteLine("First task:");

            var uniqueNamesList = peopleList
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            var titleForUniqueNames = "A and B). Get a list of unique names and output it to the console.";
            var textForUniqueNames = $"Names: {string.Join(", ", uniqueNamesList)}.";

            PrintToConsole(titleForUniqueNames, textForUniqueNames, ConsoleColor.DarkGreen);

            var averageAge = peopleList
                .Where(p => p.Age < 18)
                .Average(p => p.Age);

            var titleForAverageAge = "C). Get list of people under the age of 18 and calculate their middle age.";
            var textForAverageAge = $"Middle age for persons under the age of 18 is {averageAge}";

            PrintToConsole(titleForAverageAge, textForAverageAge, ConsoleColor.DarkBlue);

            var averageAgesByNames = peopleList
                .GroupBy(p => p.Name)
                .ToDictionary(g => g.Key, g => g.Average(p => p.Age));

            var titleForGroupByName = "D). Using grouping, get a Dictionary in which the keys are the names and the values are the average age.";
            var textForGroupByName = string.Join(Environment.NewLine, averageAgesByNames.Select(p => $"Name: {p.Key}, Average age: {p.Value}"));

            PrintToConsole(titleForGroupByName, textForGroupByName, ConsoleColor.DarkRed);

            var sortedPeopleList = peopleList
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age);

            var titleRangeAndOrder = "E). Get people whose age is from 20 to 45, output to the console their names in descending order of age.";
            var textRangeAndOrder = string.Join(Environment.NewLine, sortedPeopleList);

            PrintToConsole(titleRangeAndOrder, textRangeAndOrder, ConsoleColor.DarkYellow);

            Console.WriteLine($"{Environment.NewLine}Second task:{Environment.NewLine}");

            Console.Write("How many square roots do you want to get? Enter a positive integer: ");
            var squareRootsCount = Convert.ToInt32(Console.ReadLine());

            var squareRootsList = GetGivenSequence(GetNumbersSquareRoots(), squareRootsCount);

            PrintToConsole("List of square roots:", squareRootsList, ConsoleColor.DarkGreen);

            Console.WriteLine();
            Console.Write("How many fibonacci numbers do you want to get? Enter a positive integer: ");
            var fibonacciNumbersCount = Convert.ToInt32(Console.ReadLine());

            var fibonacciNumbersList = GetGivenSequence(GetFibonacсiNumbers(), fibonacciNumbersCount);

            PrintToConsole("List of fibonacci numbers:", fibonacciNumbersList, ConsoleColor.DarkBlue);
        }

        public static string GetGivenSequence<T>(IEnumerable<T> squareRoots, int iterationsCount)
        {
            if (iterationsCount < 0)
            {
                throw new ArgumentException($"Argument \"{nameof(iterationsCount)}\" = {iterationsCount}. "
                    + "Argument must be greater than or equal to zero.", nameof(iterationsCount));
            }

            return string.Join(Environment.NewLine, squareRoots.Take(iterationsCount));
        }

        public static IEnumerable<double> GetNumbersSquareRoots()
        {
            for (var i = 0; ; i++)
            {
                yield return Math.Sqrt(i);
            }
        }

        public static IEnumerable<int> GetFibonacсiNumbers()
        {
            var previousNumber = 1;
            var currentNumber = 0;

            yield return currentNumber;

            while (true)
            {
                var temp = currentNumber;

                currentNumber += previousNumber;

                yield return currentNumber;

                previousNumber = temp;
            }
        }

        public static void PrintToConsole(string title, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine();
            Console.WriteLine(new string('-', 110));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 110));

            Console.WriteLine(text);

            Console.WriteLine(new string('#', 110));
            Console.ResetColor();
        }

        public static List<Person> GetPeopleList()
        {
            return new List<Person>()
            {
                new Person("Иван", 99),
                new Person("Иван", 99),
                new Person("Степан", 18),
                new Person("Иван", 28),
                new Person("Вика", 32),
                new Person("Генадий", 3),
                new Person("Карл", 45),
                new Person("Зоя", 0),
                new Person("Катя", 20),
                new Person("Шура", 86),
                new Person("Клава", 9),
                new Person("Петр", 22),
                new Person("Иван", 3),
                new Person("Генадий", 7),
                new Person("Шура", 77),
                new Person("Катя", 20),
                new Person("Вика", 22),
                new Person("Людвиг", 39),
                new Person("Зоя", 16),
                new Person("Павел", 99)
            };
        }
    }
}