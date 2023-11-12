using System;

namespace P05.PrintPartOfTheASCIITable
{
    internal class PrintPartOfTheASCIITable
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
