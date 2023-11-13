using System;
using System.Linq;

namespace E02.CommonElements
{
    internal class CommonElements
    {
        static void Main(string[] args)
        {
            string[] arrOne = Console.ReadLine()
                .Split(" ")
                .ToArray();

            string[] arrTwo = Console.ReadLine()
                .Split(" ")
                .ToArray();

            for (int i = 0; i < arrTwo.Length; i++)
            {
                for (int k = 0; k < arrOne.Length; k++)
                {
                    if (arrTwo[i] == arrOne[k])
                    {
                        Console.Write($"{arrOne[k]} ");
                    }
                }
            }
        }
    }
}
