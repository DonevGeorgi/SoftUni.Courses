using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BasicStackOperations
{
    internal class BasicStackOperations
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            Stack<int> numbers = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            for (int i = 0; i < s; i++)
            {

                numbers.Pop();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
                return;
            }

            if (numbers.Any())
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
