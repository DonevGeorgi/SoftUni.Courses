using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.CupsAndBottlesTwo
{
    internal class CupsAndBottlesTwo
    {
        static void Main()
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wastedLitters = 0;
            int currCup = 0;

            while (true)
            {
                if (!bottles.Any())
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                    return;
                }

                if (!cups.Any())
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                    return;
                }

                if (currCup == 0)
                {
                    currCup = cups.Peek();
                }

                int currBottle = bottles.Peek();

                if (currBottle >= currCup)
                {
                    wastedLitters += currBottle - currCup;
                    bottles.Pop();
                    cups.Dequeue();
                    currCup = 0;
                }
                else if (currBottle < currCup)
                {
                    currCup -= currBottle;
                    bottles.Pop();
                }

            }
        }
    }
}
