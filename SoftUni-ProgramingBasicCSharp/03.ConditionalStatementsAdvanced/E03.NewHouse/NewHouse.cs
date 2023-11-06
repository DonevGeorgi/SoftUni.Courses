using System;

namespace Task03.NewHouse
{
    internal class NewHouse
    {
        static void Main()
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;

            if (flowerType == "Roses")
            {
                price = flowerCount * 5;

                if (flowerCount > 80)
                {
                    double discount = price * 0.10;
                    price -= discount;
                }
            }
            else if (flowerType == "Dahlias")
            {
                price = flowerCount * 3.80;

                if (flowerCount > 90)
                {
                    double discount = price * 0.15;
                    price -= discount;
                }
            }
            else if (flowerType == "Tulips")
            {
                price = flowerCount * 2.80;

                if (flowerCount > 80)
                {
                    double discount = price * 0.15;
                    price -= discount;
                }
            }
            else if (flowerType == "Narcissus")
            {
                price = flowerCount * 3;

                if (flowerCount < 120)
                {
                    double priceIncrese = price * 0.15;
                    price += priceIncrese;
                }
            }
            else if (flowerType == "Gladiolus")
            {
                price = flowerCount * 2.50;

                if (flowerCount < 80)
                {
                    double priceIncrese = price * 0.20;
                    price += priceIncrese;
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
            }
        }
    }
}
