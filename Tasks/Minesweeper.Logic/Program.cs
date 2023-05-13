using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading;
using System.Timers;
using Academits.Karetskas.Minesweeper.Logic;
using Academits.Karetskas.Minesweeper.Logic.Minefield;
using Academits.Karetskas.Minesweeper.Logic.FileManagement;
using Timer = System.Threading.Timer;
using System.Drawing;

namespace Minesweeper.Logic
{
    public class Program
    {
        private static int kk = 0;
        static Stopwatch stopwatch = new Stopwatch();

        public static void F1(TimeSpan t)
        {
            Console.Clear();
            Console.WriteLine(t.ToString(@"mm\:ss\:fff"));

            kk++;

            if (kk > 100)
            {
                stopwatch.Stop();
            }
        }

        static void Main()
        {
            Console.SetWindowSize(100, 50);


            HighScoresManagement highScoresManagement = new HighScoresManagement();

            //var list = highScoresManagement.GameResults;

            Console.WriteLine($"Count = {highScoresManagement.GameResults.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, highScoresManagement.GameResults));

            //stopwatch.Start();
            //stopwatch.TimeUpdate += F1;

            var gameResult = new GameResult((12, 12), 12, new TimeSpan(3, 15, 0));
            highScoresManagement.AddNewGameResultToXml(gameResult);
            highScoresManagement.SaveToXmlFile();

            //list = highScoresManagement.GameResults;

            Console.WriteLine("=======================");
            Console.WriteLine($"Count = {highScoresManagement.GameResults.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, highScoresManagement.GameResults));
            Console.WriteLine("=======================");
            Console.WriteLine();

            OptionsManagement options = new OptionsManagement();

            Console.WriteLine($"Width: {options.FieldWidth};");
            Console.WriteLine($"Length: {options.FieldHeight};");
            Console.WriteLine($"MinesCount: {options.MinesCount};");

            Console.WriteLine();
            Console.WriteLine("After");
            Console.WriteLine();

            options.FieldWidth = 15;
            options.FieldHeight = 17;
            options.MinesCount = 80;

            Console.WriteLine($"Width: {options.FieldWidth};");
            Console.WriteLine($"Length: {options.FieldHeight};");
            Console.WriteLine($"MinesCount: {options.MinesCount};");

            options.SaveToXmlFile();

            Console.WriteLine();
            Console.WriteLine("After save");
            Console.WriteLine();

            Console.WriteLine($"Width: {options.FieldWidth};");
            Console.WriteLine($"Length: {options.FieldHeight};");
            Console.WriteLine($"MinesCount: {options.MinesCount};");


            var map = new Map(10, 10, 10);

            bool isStarted = false;
            bool isSubmenu = false;
            bool MineDetected = false;
            int button = 1;
            int x = 0;
            int y = 0;
            
            while (true)
            {
                map.ShowMinesMap();

                Console.WriteLine();

                if (MineDetected)
                {
                    map.CheckAllCells();

                    isSubmenu = true;
                }

                map.ShowOpenCells();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"FoundMine: {map.MinesCount - map.MinesFoundCount}; CellsCheckedCount: {map.CellsCheckedCount}");
                Console.ForegroundColor = ConsoleColor.White;

                if (map.MinesCount == map.MinesFoundCount &&
                    map.CellsCheckedCount + map.MinesFoundCount == map.Field.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You Win!!!");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Please Y if you want to continue game: ");
                    
                    if (Console.ReadLine()?.ToUpper() == "Y")
                    {
                        isSubmenu = false;
                        isStarted = false;
                        MineDetected = false;

                        map.Clear();

                        Console.Clear();

                        continue;
                    }

                    break;
                }

                if (!isSubmenu)
                {
                    Console.WriteLine("Click:");
                    Console.WriteLine("- 1 to open a cell;");
                    Console.WriteLine("- 2 to check cells around;");
                    Console.WriteLine("- 3 to change cell status.");
                    Console.WriteLine();
                    int.TryParse(Console.ReadLine(), out button);

                    Console.Clear();
                    isSubmenu = true;

                    continue;
                }
                
                if (isSubmenu && MineDetected)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    Console.Write("Please Y if you want to continue game: ");
                    
                    if (Console.ReadLine()?.ToUpper() == "Y")
                    {
                        isSubmenu = false;
                        isStarted = false;
                        MineDetected = false;

                        map.Clear();

                        Console.Clear();

                        continue;
                    }

                    break;
                }
                
                if (button == 1)
                {
                    Console.WriteLine("Enter coordinates:");
                    Console.Write("X: ");
                    int.TryParse(Console.ReadLine(), out x);

                    Console.Write("Y: ");
                    int.TryParse(Console.ReadLine(), out y);

                    if (!isStarted)
                    {
                        map.Mine(x, y);

                        isStarted = true;
                    }

                    map.CheckCell(x, y);

                    MineDetected = map.MineDetonated;

                    isSubmenu = false;
                }
                else if (button == 2)
                {
                    Console.WriteLine("Enter coordinates:");
                    Console.Write("X: ");
                    int.TryParse(Console.ReadLine(), out x);

                    Console.Write("Y: ");
                    int.TryParse(Console.ReadLine(), out y);

                    map.CheckNearbyCells(x, y);

                    MineDetected = map.MineDetonated;
                    
                    isSubmenu = false;
                }
                else if (button == 3)
                {
                    Console.WriteLine("Enter coordinates:");
                    Console.Write("X: ");
                    int.TryParse(Console.ReadLine(), out x);

                    Console.Write("Y: ");
                    int.TryParse(Console.ReadLine(), out y);

                    map.LeaveNote(x, y);
                    
                    isSubmenu = false;
                }
                else
                {
                    isSubmenu = false;
                }

                Console.Clear();
            }
        }

        private static void Program_ev3()
        {
            throw new NotImplementedException();
        }
    }
}