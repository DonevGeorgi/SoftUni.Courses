using System;

namespace P07.WaterOverflow
{
    internal class WaterOverflow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int littreInTheTank = 255;
            int sumOfLitres = 0;

            for (int i = 0; i < n; i++)
            {
                int quantitiesOfWater = int.Parse(Console.ReadLine());

                if (littreInTheTank < quantitiesOfWater)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                littreInTheTank -= quantitiesOfWater;
                sumOfLitres += quantitiesOfWater;
            }

            Console.WriteLine($"{sumOfLitres}");
        }
    }
}
