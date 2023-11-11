using System;

namespace Problem1
{
    internal class Program
    {
        static void Main()
        {
            int fatProcentage = int.Parse(Console.ReadLine());
            int proteinPercentage = int.Parse(Console.ReadLine());
            int carbohydratesPercentage = int.Parse(Console.ReadLine());
            int totalCalories = int.Parse(Console.ReadLine());
            int waterPercentage = int.Parse(Console.ReadLine());

            double percentFat = fatProcentage / 100.0;
            double percentProtein = proteinPercentage / 100.0;
            double percentCarbohydrates = carbohydratesPercentage / 100.0;

            double totalFats = (totalCalories * percentFat) / 9;
            double totalProteins = (totalCalories * percentProtein) / 4;
            double totalCarbohydrates = (totalCalories * percentCarbohydrates) / 4;

            double totalFoodWeight = totalFats + totalProteins + totalCarbohydrates;
            double gramFood = totalCalories / totalFoodWeight;
            double totalWaterCalories = gramFood * (waterPercentage / 100.0);
            double solidFoodinGram = gramFood - totalWaterCalories;

            Console.WriteLine($"{solidFoodinGram:F4}");
        }
    }
}
