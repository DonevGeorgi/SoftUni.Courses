using System;

namespace ConsoleApp1
{
    internal class CleverLily
    {
        static void Main()
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double washingmachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int money = 0;
            int toy = 0;
            int brotherTake = 0;
            int moneyUp = 1;

            for (int i = 1; i <= lilyAge; i++)
            {


                if (i % 2 == 0)
                {
                    money += moneyUp * 10;
                    brotherTake++;

                    moneyUp++;
                }
                else
                {
                    toy++;
                }
            }

            int toyFinalPrice = toy * toyPrice;
            int finalMoney = money + toyFinalPrice - brotherTake;

            if (finalMoney >= washingmachinePrice)
            {
                Console.WriteLine($"Yes! {finalMoney - washingmachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingmachinePrice - finalMoney:f2}");
            }
        }
    }
}