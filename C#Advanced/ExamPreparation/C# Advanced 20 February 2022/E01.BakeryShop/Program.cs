using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray());

            Stack<double> flour = new Stack<double>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray());

            Dictionary<string, int> bakedProducts =
                new Dictionary<string, int>();

            bakedProducts["Bagel"] = 0;
            bakedProducts["Baguette"] = 0;
            bakedProducts["Croissant"] = 0;
            bakedProducts["Muffin"] = 0;

            while (true)
            {
                double allProducts = water.Peek() + flour.Peek();

                double currWaterPrcentage = (water.Peek() / allProducts) * 100;
                double currFlourPrcentage = (flour.Peek() / allProducts) * 100;

                if (currWaterPrcentage == 20 && currFlourPrcentage == 80)
                {
                    bakedProducts["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (currWaterPrcentage == 30 && currFlourPrcentage == 70)
                {
                    bakedProducts["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (currWaterPrcentage == 40 && currFlourPrcentage == 60)
                {
                    bakedProducts["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (currWaterPrcentage == 50 && currFlourPrcentage == 50)
                {
                    bakedProducts["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    bakedProducts["Croissant"]++;
                    flour.Push(flour.Pop() - water.Dequeue());
                }

                if (!water.Any() || !flour.Any())
                {
                    break;
                }
            }

            foreach (var baked in bakedProducts.OrderByDescending(x => x.Value))
            {
                if (baked.Value > 0)
                {
                    Console.WriteLine($"{baked.Key}: {baked.Value}");
                }
            }

            if (!water.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (!flour.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }

        }
    }
}
