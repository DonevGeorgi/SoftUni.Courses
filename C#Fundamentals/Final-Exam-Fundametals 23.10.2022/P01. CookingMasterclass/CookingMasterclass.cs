using System;

namespace P01._CookingMasterclass
{
    internal class CookingMasterclass
    {
        static void Main()
        {
            //Input
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal priceOfFlour = decimal.Parse(Console.ReadLine());
            decimal priceaOfEgg = decimal.Parse(Console.ReadLine());
            decimal priceForApron = decimal.Parse(Console.ReadLine());

            decimal freePackageOfFlour = (students / 5) * priceOfFlour;

            decimal totalPriceOfFlour = (priceOfFlour * students) - freePackageOfFlour;
            decimal totalPriceOfEggs = (priceaOfEgg * 10) * students;
            decimal bonusAprin = Math.Ceiling(students * 0.20m);
            decimal totalPriceOfAprons = priceForApron * (students + bonusAprin);

            decimal finalPrice = totalPriceOfFlour + totalPriceOfEggs + totalPriceOfAprons;

            //Output
            if (finalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {finalPrice:f2}$.");
            }
            else if (finalPrice > budget)
            {
                Console.WriteLine($"{finalPrice - budget:f2}$ more needed.");
            }
        }
    }
}