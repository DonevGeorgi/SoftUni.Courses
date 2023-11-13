using System;
using System.Linq;

namespace E07.MaxSequenceOfEqualElements
{
    internal class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int equals = 1;
            int currentLongestEquals = 0;
            int currentLongestElement = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    equals++;
                }
                else
                {
                    equals = 1;
                }

                if (equals > currentLongestEquals)
                {
                    currentLongestEquals = equals;
                    currentLongestElement = arr[i];
                }
            }

            for (int i = 1; i <= currentLongestEquals; i++)
            {
                Console.Write($"{currentLongestElement} ");
            }
        }
    }
}
