using System;

namespace E07.FoodDelivery
{
    internal class Program
    {
        static void Main()
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegeterianMenu = int.Parse(Console.ReadLine());

            double allCost = ((chickenMenu * 10.35) + (fishMenu * 12.40) + (vegeterianMenu * 8.15));

            Console.WriteLine((allCost * 0.20) + allCost + 2.50);
        }
    }
}
