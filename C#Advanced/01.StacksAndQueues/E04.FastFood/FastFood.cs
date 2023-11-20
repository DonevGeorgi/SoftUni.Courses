using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    internal class FastFood
    {
        static void Main()
        {
            int quantityFoodForTheDay = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                if ((quantityFoodForTheDay - orders.Peek()) < 0)
                {
                    break;
                }
                else
                {
                    quantityFoodForTheDay -= orders.Dequeue();
                }
            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
