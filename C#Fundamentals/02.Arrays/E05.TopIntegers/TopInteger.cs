using System;
using System.Linq;

namespace E05.TopInteger
{
    internal class TopInteger
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                bool trueTopInt = true;

                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (arr[i] <= arr[k])
                    {
                        trueTopInt = false;
                        break;
                    }
                }

                if (trueTopInt)
                {
                    Console.Write($"{arr[i]} ");
                }

            }
        }
    }
}
