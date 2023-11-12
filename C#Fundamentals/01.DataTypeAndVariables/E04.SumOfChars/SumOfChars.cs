using System;

namespace P04.SumOfChars
{
    internal class SumOfChars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int finalSum = 0;

            for (int i = 0; i < n; i++)
            {
                char currCharacter = char.Parse(Console.ReadLine());
                finalSum += (int)currCharacter;
            }

            Console.WriteLine($"The sum equals: {finalSum}");
        }
    }
}
