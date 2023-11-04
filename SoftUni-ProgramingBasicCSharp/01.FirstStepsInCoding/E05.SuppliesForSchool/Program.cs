using System;

namespace E05.SuppliesForSchool
{
    internal class Program
    {
        static void Main()
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int boardCleaner = int.Parse(Console.ReadLine());
            int discountNum = int.Parse(Console.ReadLine());

            double totalSum = ((pens * 5.80) + (markers * 7.2) + (boardCleaner * 1.2));
            double discount = discountNum / 100.0;

            Console.WriteLine(totalSum - (totalSum * discount));
        }
    }
}
