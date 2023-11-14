using System;

namespace E10.TopNumber
{
    internal class TopNumber
    {
        static void Main(string[] args)
        {
            //input
            int n = int.Parse(Console.ReadLine());

            WhichNumbersAreTopInteger(n);
        }

        static void WhichNumbersAreTopInteger(int n)
        {
            for (int i = 17; i < n; i++)
            {
                //Method for digit devide to 8
                bool isDivedeToEight = IsDigitsDevideToEight(i);

                //Method if atleast one num is odd
                bool isAtleastOneOdd = IsAtleastOneOdd(i);

                if (isDivedeToEight && isAtleastOneOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsDigitsDevideToEight(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool IsAtleastOneOdd(int num)
        {
            int current = 0;

            while (num > 0)
            {
                current = num % 10;
                num /= 10;

                if (current % 2 == 1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
