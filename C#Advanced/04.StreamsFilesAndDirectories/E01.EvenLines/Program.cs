namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                sb.Append(reader);

                int lineCount = 0;

                string line = string.Empty;

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (lineCount % 2 == 0)
                    {
                        line = ReplaceSymbols(line);
                        line = ReverseString(line);
                        sb.AppendLine(line);
                    }

                    lineCount++;
                }
            }

            return sb.ToString().TrimEnd();
        }

        static string ReplaceSymbols(string line)
        {
            char[] symbols = new char[] { '-', ',', '.', '!', '?' };

            for (int i = 0; i < line.Length; i++)
            {
                for (int k = 0; k < symbols.Length; k++)
                {
                    if (line[i] == symbols[k])
                    {
                        line = line.Replace(symbols[k], '@');
                    }
                }
            }

            return line;
        }
        static string ReverseString(string line)
        {
            string reverseString = string.Empty;

            string[] sentence = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = sentence.Length - 1; i >= 0; i--)
            {
                reverseString += " " + sentence[i];
            }

            return reverseString;
        }

    }
}
