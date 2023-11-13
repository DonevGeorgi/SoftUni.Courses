using System;
using System.Linq;

namespace E08.MagicSum
{
    internal class MagicSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int givenNum = int.Parse(Console.ReadLine());


            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = i; k < arr.Length - 1; k++)
                {
                    if (givenNum == arr[i] + arr[k + 1])
                    {
                        Console.WriteLine($"{arr[i]} {arr[k + 1]}");
                    }
                }
            }
        }
    }
}
