using System;
using System.Linq;

namespace E04.ArrayRotation
{
    internal class ArrayRotation
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            int lastDigit = 0;

            for (int i = 0; i < rotations; i++)
            {
                lastDigit = arr[0];

                for (int k = 0; k < arr.Length - 1; k++)
                {
                    arr[k] = arr[k + 1];
                }

                arr[arr.Length - 1] = lastDigit;
            }

            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
