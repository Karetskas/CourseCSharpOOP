using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Academits.Karetskas.LambdasTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First task:");

            var uniqueNamesList = GetPeopleList()
                .Select(person => person.Name)
                .Distinct()
                .ToList();

            var titleForUniqueNames = "A and B). Get a list of unique names and output it to the console.";
            var textForUniqueNames = $"Names: {string.Join(", ", uniqueNamesList)}.";

            PrintToConsole(titleForUniqueNames, textForUniqueNames, ConsoleColor.DarkGreen);

            var middleAge = GetPeopleList()
                .Where(person => person.Age < 18)
                .Average(person => person.Age);

            var titleForMiddleAge = "C). Get list of people under the age of 18 and calculate their middle age.";
            var textForMiddleAge = $"Middle age for persons under the age of 18 is {middleAge}";

            PrintToConsole(titleForMiddleAge, textForMiddleAge, ConsoleColor.DarkBlue);

            var groupPersonByName = GetPeopleList()
                .GroupBy(person => person.Name)
                .ToDictionary(groupName => groupName.Key, person => person.Average(person => person.Age));

            var titleForGroupByName = "D). Using grouping, get a Dictionary in which the keys are the names and the values are the average age.";
            var textForGroupByName = string.Join(Environment.NewLine, groupPersonByName.Select(persons => $"Group: {persons.Key}, Average: {persons.Value}"));

            PrintToConsole(titleForGroupByName, textForGroupByName, ConsoleColor.DarkRed);

            var peopleList = GetPeopleList()
                .Where(person => person.Age >= 20 && person.Age <= 45)
                .OrderByDescending(person => person.Age);

            var titleRangeAndOrder = "E). Get people whose age is from 20 to 45, output to the console their names in descending order of age.";
            var textRangeAndOrder = string.Join(Environment.NewLine, peopleList);

            PrintToConsole(titleRangeAndOrder, textRangeAndOrder, ConsoleColor.DarkYellow);

            Console.WriteLine($"{Environment.NewLine}Second task:{Environment.NewLine}");

            Console.Write("How many square roots do you want to get? Enter a positive integer: ");
            int squareRootsCount = Convert.ToInt32(Console.ReadLine());

            StringBuilder stringBuilderSquareRootNumbers = GetGivenSequance(GetNumbersSquareRoots, squareRootsCount, "square root");

            PrintToConsole("List of square roots:", stringBuilderSquareRootNumbers.ToString(), ConsoleColor.DarkGreen);

            Console.WriteLine();
            Console.Write("How many fibonacci numbers do you want to get? Enter a positive integer: ");
            int fibonacciNumbersCount = Convert.ToInt32(Console.ReadLine());

            StringBuilder stringBuilderFibonacciNumbers = GetGivenSequance(GetFibonacсiNumbers, fibonacciNumbersCount, "fibonacci number");

            PrintToConsole("List of fibonacci numbers:", stringBuilderFibonacciNumbers.ToString(), ConsoleColor.DarkBlue);
        }

        public static StringBuilder GetGivenSequance<T>(Func<IEnumerable<T>> function, int iterationsCount, string outputDataType)
        {
            if (iterationsCount < 0)
            {
                throw new ArgumentException($"Argument \"{nameof(iterationsCount)}\" = {iterationsCount}. "
                    + $"Argument must be greater than or equal to zero.", nameof(iterationsCount));
            }

            if (string.IsNullOrEmpty(outputDataType))
            {
                throw new ArgumentNullException(nameof(outputDataType), $"Argument \"{nameof(outputDataType)}\" is null or empty.");
            }

            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;

            foreach (var result in function())
            {
                stringBuilder.AppendLine($"{i}). {outputDataType} = {result}");

                if (i >= iterationsCount)
                {
                    break;
                }

                i++;
            }

            return stringBuilder;
        }

        public static IEnumerable<double> GetNumbersSquareRoots()
        {
            for (int i = 0; ; i++)
            {
                yield return Math.Sqrt(i);
            }
        }

        public static IEnumerable<int> GetFibonacсiNumbers()
        {
            int previousNumber = -1;
            int fibonacciNumber = 0;

            yield return fibonacciNumber;

            while (true)
            {
                previousNumber = fibonacciNumber - previousNumber;

                fibonacciNumber += previousNumber;

                yield return fibonacciNumber;
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
            var people = new List<Person>();

            people.Add(new Person("Иван", 99));
            people.Add(people[0]);
            people.Add(new Person("Степан", 18));
            people.Add(new Person("Иван", 28));
            people.Add(new Person("Вика", 32));
            people.Add(new Person("Генадий", 3));
            people.Add(new Person("Карл", 45));
            people.Add(new Person("Зоя", 0));
            people.Add(new Person("Катя", 20));
            people.Add(new Person("Шура", 86));
            people.Add(new Person("Клава", 9));
            people.Add(new Person("Петр", 22));
            people.Add(new Person("Иван", 3));
            people.Add(new Person("Генадий", 7));
            people.Add(new Person("Шура", 77));
            people.Add(new Person("Катя", 20));
            people.Add(new Person("Вика", 22));
            people.Add(new Person("Людвиг", 39));
            people.Add(new Person("Зоя", 16));
            people.Add(new Person("Павел", 99));

            return people;
        }
    }
}