using System;

namespace P06.TriangleOfLatinLetters
{
    internal class TrippleOfLatinLatters
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char firstChar = (char)('a' + i);

                for (int k = 0; k < n; k++)
                {
                    char secondChar = (char)('a' + k);

                    for (int j = 0; j < n; j++)
                    {
                        char thirdChar = (char)('a' + j);
                        Console.Write($"{firstChar}{secondChar}{thirdChar}");
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
