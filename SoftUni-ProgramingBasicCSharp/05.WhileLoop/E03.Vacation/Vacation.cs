using System;

namespace Task03.Vacation
{
    internal class Vacation
    {
        static void Main()
        {
            double neededForVacationMoney = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());

            int spendCounter = 0;
            int totalDaySpend = 0;

            while (balance < neededForVacationMoney)
            {
                string action = Console.ReadLine();

                double amount = double.Parse(Console.ReadLine());

                totalDaySpend++;

                if (action == "spend")
                {
                    balance -= amount;

                    spendCounter++;
                    if (spendCounter == 5)
                    {
                        break;
                    }
                    if (balance < 0)
                    {
                        balance = 0;
                    }
                }

                if (action == "save")
                {
                    balance += amount;
                    spendCounter = 0;
                }
            }

            if (balance >= neededForVacationMoney)
            {
                Console.WriteLine($"You saved the money for {totalDaySpend} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(totalDaySpend);
            }
        }
    }
}
