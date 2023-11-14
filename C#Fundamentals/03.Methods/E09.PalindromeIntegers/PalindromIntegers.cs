using System;
using System.Linq;

namespace E09.PalindromInteger
{
    internal class PalindromIntegers
    {
        static void Main(string[] args)
        {
            //input while is diferent from END
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                //input parse to num
                int number = int.Parse(input);

                //Make sure is always
                Math.Abs(number);

                //Method for finding if number in palindrom
                bool isPalindrom = IsPalindromNumber(number);


                if (isPalindrom)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool IsPalindromNumber(int num)
        {
            int numCopy = num;
            int reverseInt = 0;

            while (num > 0)
            {
                reverseInt = reverseInt * 10 + num % 10;
                num /= 10;
            }

            if (numCopy == reverseInt)
            {
                return true;
            }

            return false;

        }
    }
}
