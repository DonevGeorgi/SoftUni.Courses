using System;
using System.Linq;

namespace P08.LettersChangeNumbers
{
    internal class LettersChangeNumbers
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += ProcessingInput(input[i]);
            }

            Console.WriteLine($"{sum:f2}");
        }

        static double ProcessingInput(string input)
        {
            char firstLetter = input[0];
            char lastLetter = input[input.Length - 1];

            string diggitsFromString = input[1..(input.Length - 1)];
            double diggits = double.Parse(diggitsFromString);

            if (char.IsUpper(firstLetter))
            {
                int positionOfTheLetter = firstLetter - 64;
                diggits /= positionOfTheLetter;
            }
            else
            {
                int positionOfTheLetter = firstLetter - 96;
                diggits *= positionOfTheLetter;
            }

            if (char.IsUpper(lastLetter))
            {
                int positionOfTheLetter = lastLetter - 64;
                diggits -= positionOfTheLetter;
            }
            else
            {
                int positionOfTheLetter = lastLetter - 96;
                diggits += positionOfTheLetter;
            }

            return diggits;
        }
    }
}
