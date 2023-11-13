using System;

namespace E01.Train
{
    internal class Train
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] passengers = new int[n];

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < passengers.Length; i++)
            {
                sum += passengers[i];
            }

            Console.WriteLine(String.Join(" ", passengers));
            Console.WriteLine(sum);
        }
    }
}
