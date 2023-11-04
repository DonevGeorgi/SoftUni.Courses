using System;

namespace E01.USDToBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double uSD = double.Parse(Console.ReadLine());

            Console.WriteLine(uSD * 1.79549);
        }
    }
}