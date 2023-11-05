using System;

namespace _05.Godzilla_vs._Kong
{
    internal class GodzillavsKong
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int stuntMans = int.Parse(Console.ReadLine());
            double priceForStuntManSuit = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;
            double priceOfTheStuntManSuits = priceForStuntManSuit * stuntMans;

            if (stuntMans > 150)
            {
                double discount = priceOfTheStuntManSuits * 0.10;
                priceOfTheStuntManSuits -= discount;
            }

            double totalPrice = decor + priceOfTheStuntManSuits;

            if (totalPrice > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalPrice - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - totalPrice:f2} leva left.");
            }
        }
    }
}
