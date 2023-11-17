using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountCharsInAString
{
    public class CountCharsInAString
    {
        static void Main()
        {
            Dictionary<char, int> charsInWord =
                new Dictionary<char, int>();

            string[] word = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string letters in word)
            {
                foreach (char letter in letters)
                {
                    if (!charsInWord.ContainsKey(letter))
                    {
                        charsInWord.Add(letter, 0);
                    }

                    charsInWord[letter]++;
                }
            }

            foreach (var letter in charsInWord)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
