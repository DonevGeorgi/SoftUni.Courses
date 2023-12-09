using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Stack<int> secondLootBox = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            List<int> claimedItems = new List<int>();

            while (true)
            {
                int sum = firstLootBox.Peek() + secondLootBox.Peek();

                if (sum % 2 == 0)
                {
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                    claimedItems.Add(sum);
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }

                if (!firstLootBox.Any() || !secondLootBox.Any())
                {
                    break;
                }
            }

            if (!firstLootBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondLootBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}

