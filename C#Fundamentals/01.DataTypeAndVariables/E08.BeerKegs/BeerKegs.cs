using System;

namespace P08.BeerKegs
{
    internal class BeerKegs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string modelOfTheBiggestKeg = string.Empty;
            double volumeOfTheBiggestKeg = 0;

            for (int i = 0; i < n; i++)
            {
                string modelOfTheKeg = Console.ReadLine();
                double radiusOfTheKeg = double.Parse(Console.ReadLine());
                int heightOfTheKeg = int.Parse(Console.ReadLine());

                double kegsVolume = Math.PI * Math.Pow(radiusOfTheKeg, 2) * heightOfTheKeg;

                if (volumeOfTheBiggestKeg < kegsVolume)
                {
                    modelOfTheBiggestKeg = modelOfTheKeg;
                    volumeOfTheBiggestKeg = kegsVolume;
                }
            }

            Console.WriteLine($"{modelOfTheBiggestKeg}");
        }
    }
}
