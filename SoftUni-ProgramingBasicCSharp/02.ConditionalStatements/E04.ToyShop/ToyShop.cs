using System;

namespace _04.ToyShop
{
    internal class ToyShop
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzelsCount = int.Parse(Console.ReadLine());
            int talkingDollCount = int.Parse(Console.ReadLine());
            int plushBearCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double totalPriceOfTheToys = (puzzelsCount * 2.60) + (talkingDollCount * 3) + (plushBearCount * 4.10) + (minionsCount * 8.20) + (trucks * 2);
            double totalCountOfTheToys = puzzelsCount + talkingDollCount + plushBearCount + minionsCount + trucks;

            if (totalCountOfTheToys >= 50)
            {
                totalPriceOfTheToys -= (totalPriceOfTheToys * 0.25);
            }

            totalPriceOfTheToys -= (totalPriceOfTheToys * 0.10);

            if (totalPriceOfTheToys >= vacationPrice)
            {
                Console.WriteLine($"Yes! {totalPriceOfTheToys - vacationPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacationPrice - totalPriceOfTheToys:f2} lv needed.");
            }



        }
    }
}
