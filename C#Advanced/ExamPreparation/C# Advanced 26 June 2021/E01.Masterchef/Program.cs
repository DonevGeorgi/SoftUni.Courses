using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingrediantValue = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Stack<int> freshnessLevel = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Dictionary<string, int> ingrediants
                = new Dictionary<string, int>();

            ingrediants["Chocolate cake"] = 0;
            ingrediants["Dipping sauce"] = 0;
            ingrediants["Green salad"] = 0;
            ingrediants["Lobster"] = 0;

            while (true)
            {
                if (ingrediantValue.Peek() == 0)
                {
                    ingrediantValue.Dequeue();
                }
                else
                {
                    int totalFreshnessLevel = ingrediantValue.Peek() * freshnessLevel.Peek();

                    switch (totalFreshnessLevel)
                    {
                        case 150:

                            ingrediants["Dipping sauce"]++;
                            ingrediantValue.Dequeue();
                            freshnessLevel.Pop();

                            break;

                        case 250:

                            ingrediants["Green salad"]++;
                            ingrediantValue.Dequeue();
                            freshnessLevel.Pop();

                            break;

                        case 300:

                            ingrediants["Chocolate cake"]++;
                            ingrediantValue.Dequeue();
                            freshnessLevel.Pop();

                            break;

                        case 400:

                            ingrediants["Lobster"]++;
                            ingrediantValue.Dequeue();
                            freshnessLevel.Pop();

                            break;

                        default:

                            freshnessLevel.Pop();
                            ingrediantValue.Enqueue(ingrediantValue.Dequeue() + 5);

                            break;
                    }
                }

                if (!ingrediantValue.Any() || !freshnessLevel.Any())
                {
                    break;
                }
            }

            if (ingrediants.All(x => x.Value != 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingrediantValue.Any())
            {
                int sum = ingrediantValue.Sum();

                Console.WriteLine($"Ingredients left: {sum}");
            }

            foreach (var ingrediant in ingrediants)
            {
                if (ingrediant.Value > 0)
                {
                    Console.WriteLine($" # {ingrediant.Key} --> {ingrediant.Value}");
                }
            }
        }
    }
}

