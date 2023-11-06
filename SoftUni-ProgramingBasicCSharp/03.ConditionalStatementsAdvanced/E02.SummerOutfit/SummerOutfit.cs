using System;

namespace Task03.SummerOutfit
{
    internal class SummerOutfit
    {
        static void Main()
        {
            int degree = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            if (degree >= 10 && degree <= 18)
            {
                if (timeOfDay == "Morning")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Sweatshirt and Sneakers.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Shirt and Moccasins.");
                }
                else if (timeOfDay == "Evening")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Shirt and Moccasins.");
                }
            }
            else if (degree > 18 && degree <= 24)
            {
                if (timeOfDay == "Morning")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Shirt and Moccasins.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    Console.WriteLine($"It's {degree} degrees, get your T-Shirt and Sandals.");
                }
                else if (timeOfDay == "Evening")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Shirt and Moccasins.");
                }
            }
            else if (degree >= 25)
            {
                if (timeOfDay == "Morning")
                {
                    Console.WriteLine($"It's {degree} degrees, get your T-Shirt and Sandals.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Swim Suit and Barefoot.");
                }
                else if (timeOfDay == "Evening")
                {
                    Console.WriteLine($"It's {degree} degrees, get your Shirt and Moccasins.");
                }
            }
        }
    }
}
