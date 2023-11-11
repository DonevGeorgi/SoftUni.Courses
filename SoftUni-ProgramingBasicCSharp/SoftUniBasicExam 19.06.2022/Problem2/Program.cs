using System;

namespace Problem2
{
    internal class Program
    {
        static void Main()
        {
            int daysGone = int.Parse(Console.ReadLine());
            int foodKG = int.Parse(Console.ReadLine());
            double foodDeerOne = double.Parse(Console.ReadLine());
            double foodDeerTwo = double.Parse(Console.ReadLine());
            double foodDeerThree = double.Parse(Console.ReadLine());

            double totalFoodDeerOne = daysGone * foodDeerOne;
            double totalFoodDeerTwo = daysGone * foodDeerTwo;
            double totalFoodDeerThree = daysGone * foodDeerThree;
            double totalFoodEaten = totalFoodDeerOne + totalFoodDeerTwo + totalFoodDeerThree;

            if (foodKG >= totalFoodEaten)
            {
                double leftKG = foodKG - totalFoodEaten;
                Console.WriteLine($"{Math.Floor(leftKG)} kilos of food left.");
            }
            else
            {
                double neededKG = totalFoodEaten - foodKG;
                Console.WriteLine($"{Math.Ceiling(neededKG)} more kilos of food are needed.");
            }
        }
    }
}
