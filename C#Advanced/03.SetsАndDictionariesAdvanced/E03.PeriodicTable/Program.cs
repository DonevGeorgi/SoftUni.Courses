using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();


            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < elements.Length; k++)
                {
                    periodicTable.Add(elements[k]);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
