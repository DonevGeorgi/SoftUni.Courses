using System;
using System.Linq;

namespace E06.EqualSums
{
    internal class EqualSums
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            if (arr.Length < 2)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                if (arr[i] != arr.Length)
                {
                    for (int k = i + 1; k < arr.Length; k++)
                    {
                        rightSum += arr[k];
                    }
                }

                if (arr[i] != arr[0])
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        leftSum += arr[k];
                    }

                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
