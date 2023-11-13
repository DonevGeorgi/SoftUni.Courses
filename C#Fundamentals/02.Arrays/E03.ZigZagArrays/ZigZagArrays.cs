using System;
using System.Linq;

namespace E03.ZigZagArrays
{
    internal class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrOne = new int[n];
            int[] arrTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int numOne = numbers[0];
                int numTwo = numbers[1];

                if (i % 2 == 0)
                {
                    arrOne[i] = numOne;
                    arrTwo[i] = numTwo;
                }
                else
                {
                    arrOne[i] = numTwo;
                    arrTwo[i] = numOne;
                }
            }

            Console.WriteLine(String.Join(" ", arrOne));
            Console.WriteLine(String.Join(" ", arrTwo));
        }
    }
}
