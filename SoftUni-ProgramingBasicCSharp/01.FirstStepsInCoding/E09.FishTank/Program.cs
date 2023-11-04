using System;

namespace E09.FishTank
{
    internal class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double procentageStuffNum = double.Parse(Console.ReadLine());

            double size = length * width * height / 1000.0;
            double procentageTaken = procentageStuffNum / 100;

            Console.WriteLine(size * (1 - procentageTaken));
        }
    }
}
