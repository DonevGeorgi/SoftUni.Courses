using System;

namespace Task05.SpecialNumbers
{
    internal class SpecialNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int misionSaveI = i;

                bool isMagical = true;

                for (int j = 1; j <= 4; j++)
                {
                    int lastDigit = misionSaveI % 10;

                    if (lastDigit == 0)
                    {
                        isMagical = false;
                        break;
                    }

                    int remainder = number % lastDigit;

                    if (remainder != 0)
                    {
                        isMagical = false;
                        break;
                    }

                    if (j < 4)
                    {
                        misionSaveI /= 10;
                    }
                }

                if (isMagical)
                {
                    Console.Write($"{i} ");
                }

            }
        }
    }
}
