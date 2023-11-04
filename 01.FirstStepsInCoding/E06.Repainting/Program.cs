using System;

namespace E06.Repainting
{
    internal class Program
    {
        static void Main()
        {
            int plasticFoil = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int workHour = int.Parse(Console.ReadLine());

            double allCost = (((plasticFoil + 2) * 1.5) + ((paint + (paint * 0.10)) * 14.5) + (thinner * 5.00) + 0.40);

            double workerCost = (allCost * 0.30) * workHour;

            Console.WriteLine(allCost + workerCost);
        }
    }
}