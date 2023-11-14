using System;
using System.Linq;

namespace E02.VowelsCount
{
    internal class VowelsCount
    {
        static void Main(string[] args)
        {
            //Input
            string input = Console.ReadLine();

            //Using Method Output
            VowelsSum(input);
        }

        static void VowelsSum(string input)
        {
            input = input.ToLower();

            char[] inputLatters = input.ToCharArray();

            char[] vowerLatters = { 'a', 'e', 'i', 'o', 'u', 'y' };

            int sumOfLetters = 0;

            for (int i = 0; i < inputLatters.Length; i++)
            {
                for (int k = 0; k < vowerLatters.Length; k++)
                {
                    if (inputLatters[i] == vowerLatters[k])
                    {
                        sumOfLetters++;
                    }
                }
            }

            Console.WriteLine(sumOfLetters);
        }
    }
}
