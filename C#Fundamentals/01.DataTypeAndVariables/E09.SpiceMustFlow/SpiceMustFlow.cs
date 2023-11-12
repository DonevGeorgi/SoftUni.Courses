using System;

namespace P09.SpiceMustFlow
{
    internal class SpiceMustFlow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int yieldCopy = 0;
            int totalSum = 0;
            int daysWorked = 0;

            while (n >= 0)
            {
                yieldCopy = n;

                if (n < 100)
                {
                    if (n >= 26 && daysWorked != 0)
                    {
                        totalSum -= 26;
                    }

                    Console.WriteLine(daysWorked);
                    Console.WriteLine(totalSum);
                    break;
                }

                daysWorked++;
                yieldCopy -= 26;
                totalSum += yieldCopy;

                n -= 10;


            }
        }
    }
}
