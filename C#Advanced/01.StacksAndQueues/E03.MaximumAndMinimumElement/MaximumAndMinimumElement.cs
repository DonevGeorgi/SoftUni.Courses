using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MaximumAndMinimumElement
{
    internal class MaximumAndMinimumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> sequence = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (command[0] == 1)
                {
                    sequence.Push(command[1]);
                }
                else if (command[0] == 2 && sequence.Any())
                {
                    sequence.Pop();
                }
                else if (command[0] == 3 && sequence.Any())
                {
                    Console.WriteLine(sequence.Max());
                }
                else if (command[0] == 4 && sequence.Any())
                {
                    Console.WriteLine(sequence.Min());
                }
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
