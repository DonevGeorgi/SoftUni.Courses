using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Probe
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> quantityOfCoffee = new Queue<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Stack<int> quantityOfMilk = new Stack<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Dictionary<string, int> coffeeDrinks
                = new Dictionary<string, int>();

            coffeeDrinks.Add("Latte", 0);
            coffeeDrinks.Add("Espresso", 0);
            coffeeDrinks.Add("Cortado", 0);
            coffeeDrinks.Add("Capuccino", 0);
            coffeeDrinks.Add("Americano", 0);

            while (true)
            {
                if (!quantityOfCoffee.Any() && !quantityOfMilk.Any())
                {
                    Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                    break;
                }

                if (!quantityOfCoffee.Any() || !quantityOfMilk.Any())
                {
                    Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                    break;
                }

                int currQuantity = quantityOfCoffee.Peek() + quantityOfMilk.Peek();

                switch (currQuantity)
                {
                    case 50:

                        quantityOfMilk.Pop();
                        quantityOfCoffee.Dequeue();
                        coffeeDrinks["Cortado"] += 1;

                        break;

                    case 75:

                        quantityOfMilk.Pop();
                        quantityOfCoffee.Dequeue();
                        coffeeDrinks["Espresso"] += 1;

                        break;

                    case 100:

                        quantityOfMilk.Pop();
                        quantityOfCoffee.Dequeue();
                        coffeeDrinks["Capuccino"] += 1;

                        break;

                    case 150:

                        quantityOfMilk.Pop();
                        quantityOfCoffee.Dequeue();
                        coffeeDrinks["Americano"] += 1;

                        break;

                    case 200:

                        quantityOfMilk.Pop();
                        quantityOfCoffee.Dequeue();
                        coffeeDrinks["Latte"] += 1;

                        break;

                    default:

                        quantityOfCoffee.Dequeue();
                        quantityOfMilk.Push(quantityOfMilk.Pop() - 5);


                        break;
                }

            }

            if (!quantityOfCoffee.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", quantityOfCoffee)}");
            }

            if (!quantityOfMilk.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", quantityOfMilk)}");
            }

            foreach (var currDrink in coffeeDrinks.OrderBy(x => x.Value))
            {
                if (currDrink.Value > 0)
                {
                    Console.WriteLine($"{currDrink.Key}: {currDrink.Value}");
                }
            }
        }
    }
}
