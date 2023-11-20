using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    internal class FashionBoutique
    {
        static void Main()
        {
            Stack<int> clothes = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int rack = int.Parse(Console.ReadLine());

            int countOfRacks = 1;
            int sum = 0;

            while (clothes.Any())
            {
                if ((sum + clothes.Peek()) > rack)
                {
                    countOfRacks++;
                    sum = 0;

                    continue;
                }

                sum += clothes.Pop();
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
