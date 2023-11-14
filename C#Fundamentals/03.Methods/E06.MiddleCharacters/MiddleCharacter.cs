using System;

namespace E06.MiddleCharacter
{
    internal class MiddleCharacter
    {
        static void Main(string[] args)
        {
            //input
            string input = Console.ReadLine();


            FindingMiddleCharacter(input);
        }

        static void FindingMiddleCharacter(string input)
        {
            int len = input.Length;

            string result = string.Empty;

            if (len % 2 == 1)
            {
                result = input[input.Length / 2].ToString();
            }
            else if (len % 2 == 0)
            {
                result = input[input.Length / 2 - 1].ToString() + input[input.Length / 2].ToString();
            }

            //output
            Console.WriteLine(result);
        }
    }
}
