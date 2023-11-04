using System;

namespace E03.DepositCalculator
{
    internal class Program
    {
        static void Main()
        {
            double depMoney = double.Parse(Console.ReadLine());
            int depInMonth = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());

            Console.WriteLine(depMoney + depInMonth * ((depMoney * (interest / 100)) / 12));
        }
    }
}