using System;
using System.Text;

namespace P04.CaeserCipher
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder cipher = new StringBuilder();

            foreach (char letter in input)
            {
                int currentChar = letter;
                currentChar += 3;
                cipher.Append((char)currentChar);
            }

            Console.WriteLine(cipher.ToString());
        }
    }
}
