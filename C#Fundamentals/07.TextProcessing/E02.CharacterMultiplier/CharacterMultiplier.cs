using System;

namespace E02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            GetStringSum(input[0], input[1]);
        }

        private static void GetStringSum(string stringOne, string stringTwo)
        {
            int sum = 0;
            int minLength = Math.Min(stringOne.Length, stringTwo.Length);
            for (int i = 0; i < minLength; i++)
            {
                sum += stringOne[i] * stringTwo[i];
            }

            string longestLegthString = stringOne;
            if (longestLegthString.Length < stringTwo.Length)
            {
                longestLegthString = stringTwo;
            }
            for (int i = minLength; i < longestLegthString.Length; i++)
            {
                sum += longestLegthString[i];
            }
            Console.WriteLine(sum);
        }
    }
}