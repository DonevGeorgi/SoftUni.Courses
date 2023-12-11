using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Queue<int> scarfs = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());


            List<int> sets = new List<int>();

            while (true)
            {
                if (scarfs.Peek() < hats.Peek())
                {
                    sets.Add(scarfs.Dequeue() + hats.Pop());
                }
                else if (scarfs.Peek() > hats.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }

                if (!scarfs.Any() || !hats.Any())
                {
                    break;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}

