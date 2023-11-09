using System;

namespace Task05.Coins
{
    internal class Coins
    {
        static void Main()
        {
            decimal change = decimal.Parse(Console.ReadLine());

            int coinsNumber = 0;

            while (change > 0.00m)
            {
                if (change >= 2.00m)
                {
                    change -= 2.00m;
                }
                else if (change >= 1.00m)
                {
                    change -= 1.00m;
                }
                else if (change >= 0.50m)
                {
                    change -= 0.50m;
                }
                else if (change >= 0.20m)
                {
                    change -= 0.20m;
                }
                else if (change >= 0.10m)
                {
                    change -= 0.10m;
                }
                else if (change >= 0.05m)
                {
                    change -= 0.05m;
                }
                else if (change >= 0.02m)
                {
                    change -= 0.02m;
                }
                else if (change >= 0.01m)
                {
                    change -= 0.01m;
                }

                coinsNumber++;
            }

            Console.WriteLine(coinsNumber);
        }
    }
}
