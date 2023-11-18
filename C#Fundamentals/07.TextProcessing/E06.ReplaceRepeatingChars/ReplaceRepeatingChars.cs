using System;

namespace P06.ReplaceRepeatingChars
{
    internal class ReplaceRelpeatingChars
    {
        static void Main()
        {
            string input = Console.ReadLine();

            char currChar = ' ';

            foreach (char letter in input)
            {
                if (!(currChar == letter))
                {
                    currChar = letter;
                    Console.Write(currChar);
                }
            }
        }
    }
}
