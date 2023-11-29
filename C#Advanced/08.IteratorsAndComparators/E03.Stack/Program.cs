using System;
using System.Linq;

namespace P03.Stack
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Skip(1)
                .ToArray();

            CustomStack<int> numbers = new();

            foreach (var number in input)
            {
                numbers.Push(number);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Pop")
                {
                    try
                    {
                        numbers.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (commandArgs[0] == "Push")
                {
                    int element = int.Parse(commandArgs[1]);

                    numbers.Push(element);
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
