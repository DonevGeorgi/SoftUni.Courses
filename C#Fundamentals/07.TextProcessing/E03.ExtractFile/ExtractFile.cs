using System;
using System.Linq;

namespace P03.ExtractFile
{
    internal class ExtractFile
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string[] InputArgs = input[input.Length - 1]
                .Split(".", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine($"File name: {InputArgs[0]}");
            Console.WriteLine($"File extension: {InputArgs[1]}");
        }
    }
}
