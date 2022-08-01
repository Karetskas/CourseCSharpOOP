using System;
using System.IO;
using System.Security;
using System.Text;

namespace Academits.Karetskas
{
    internal class Csv
    {
        static int Main(string[] args)
        {
            Console.WriteLine();

            if (args.Length == 1 && args[0].Equals("help", StringComparison.CurrentCultureIgnoreCase))
            {
                PrintHelp();

                return 1;
            }

            if (args.Length != 2)
            {
                Console.WriteLine("You have entered too few or too many arguments.");
                PrintHelp();

                return 1;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"Error!!! I can't find the file in this path: {args[0]}");

                return 1;
            }

            Console.WriteLine("Please, wait...");

            bool isError = false;

            try
            {
                if (!ConvertTableFromCsvFormatToHtml(args[0], args[1]))
                {
                    Console.WriteLine($"Error in the syntax of the file \"{Path.GetFileName(args[0])}\".");

                    return 1;
                }
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (EncoderFallbackException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e);

                isError = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                isError = true;
            }

            if (isError)
            {
                Console.WriteLine("Tasks not completed :(");

                return 1;
            }

            Console.WriteLine("Tasks completed :)");

            return 0;
        }

        public static void PrintHelp()
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Please enter two arguments:");
            Console.WriteLine();
            Console.WriteLine("- The first argument is the path to the file to read.");
            Console.WriteLine("For example: \"C:\\MyFolder\\FileToRead.csv\"");
            Console.WriteLine();
            Console.WriteLine("- The second argument is the path to the saved file with its name and extension.");
            Console.WriteLine("For example: \"C:\\MyFolder\\FileToSave.html\"");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();
        }

        public static bool ConvertTableFromCsvFormatToHtml(string pathToSourceFile, string pathToResultingFile)
        {
            using StreamWriter writer = new StreamWriter(pathToResultingFile);

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine(new string('\t', 1) + "<head>");
            writer.WriteLine(new string('\t', 2) + "<meta charset=\"utf-8\">");
            writer.WriteLine(new string('\t', 2) + "<title>Table int HTML5</title>");
            writer.WriteLine(new string('\t', 2) + "<style>");
            writer.WriteLine(new string('\t', 3) + "table {");
            writer.WriteLine(new string('\t', 3) + "border-spacing: 0px;");
            writer.WriteLine(new string('\t', 3) + "text-align: left;");
            writer.WriteLine(new string('\t', 3) + "}");
            writer.WriteLine(new string('\t', 2) + "</style>");
            writer.WriteLine(new string('\t', 1) + "</head>");
            writer.WriteLine(new string('\t', 1) + "<body>");
            writer.WriteLine(new string('\t', 2) + "<table border=\"1\">");

            bool isError = false;
            bool isCell = false;
            bool isTableRow = false;
            bool isCellWithQuotes = false;
            bool isCellFirstSymbol = false;
            bool isQuoteFirstPair = false;
            char symbol;

            using StreamReader reader = new StreamReader(pathToSourceFile);

            while ((symbol = (char)reader.Read()) != '\uffff')
            {
                if (symbol == '\r' || (!isTableRow && !isCell && !isCellFirstSymbol && symbol == '\n'))
                {
                    continue;
                }

                if (!isTableRow)
                {
                    writer.WriteLine(new string('\t', 3) + "<tr>");

                    isTableRow = true;
                }

                if (!isCell)
                {
                    writer.Write(new string('\t', 4) + "<td>");

                    isCell = true;

                    isCellFirstSymbol = true;
                }

                if (symbol == '"')
                {
                    if (isCellFirstSymbol)
                    {
                        isCellWithQuotes = true;
                        isCellFirstSymbol = false;

                        continue;
                    }

                    if (!isQuoteFirstPair)
                    {
                        isQuoteFirstPair = true;

                        continue;
                    }

                    if (!isCellWithQuotes)
                    {
                        isError = true;

                        break;
                    }

                    isQuoteFirstPair = false;

                    writer.Write(symbol);

                    continue;
                }

                if (symbol == '\n')
                {
                    if (isCellWithQuotes && !isQuoteFirstPair)
                    {
                        writer.Write("<br />" + Environment.NewLine + new string('\t', 4));

                        continue;
                    }

                    if (isQuoteFirstPair)
                    {
                        isQuoteFirstPair = false;
                        isCellWithQuotes = false;
                    }

                    isCellFirstSymbol = false;
                    isCell = false;
                    isTableRow = false;
                }

                if (symbol == ',')
                {
                    if (isCellWithQuotes && !isQuoteFirstPair)
                    {
                        writer.Write(symbol);

                        continue;
                    }

                    if (isQuoteFirstPair)
                    {
                        isQuoteFirstPair = false;
                        isCellWithQuotes = false;
                    }

                    isCellFirstSymbol = false;
                    isCell = false;
                }

                if (!isCell)
                {
                    writer.WriteLine("</td>");

                    if (!isTableRow)
                    {
                        writer.WriteLine(new string('\t', 3) + "</tr>");
                    }

                    continue;
                }

                if (isQuoteFirstPair)
                {
                    isError = true;

                    break;
                }

                if (isCellFirstSymbol)
                {
                    isCellFirstSymbol = false;
                }

                if (symbol == '&')
                {
                    writer.Write("&amp;");
                }
                else if (symbol == '>')
                {
                    writer.Write("&gt;");
                }
                else if (symbol == '<')
                {
                    writer.Write("&lt;");
                }
                else
                {
                    writer.Write(symbol);
                }
            }

            if (isError || isCellWithQuotes != isQuoteFirstPair)
            {
                writer.Close();

                File.Delete(pathToResultingFile);

                return false;
            }

            if (isCell || isTableRow)
            {
                string text = "";

                if (isTableRow && !isQuoteFirstPair && !isCell)
                {
                    text = new string('\t', 4) + "<td>";
                }

                text += "</td>" + Environment.NewLine + new string('\t', 3) + "</tr>";

                writer.WriteLine(text);
            }

            writer.WriteLine(new string('\t', 2) + "</table>");
            writer.WriteLine(new string('\t', 1) + "</body>");
            writer.WriteLine("</html>");

            return true;
        }
    }
}