using System;

namespace Task02.EqualSumsEvenOddPositions
{
    internal class EqualSumsEvenOddPositions
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int currentNum = 0;
            int counter = 0;
            int oddSum = 0;
            int evenSum = 0;

            bool flag = false;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                currentNum = i;
                counter = 0;
                evenSum = 0;
                oddSum = 0;
                flag = false;

                for (int j = 1; j <= 6; j++)
                {
                    int res = currentNum % 10;
                    counter++;

                    if (counter % 2 == 0)
                    {
                        oddSum += res;
                    }
                    else if (counter % 2 != 0)
                    {
                        evenSum += res;
                    }

                    if (counter == 6)
                    {
                        flag = true;
                        break;
                    }

                    currentNum /= 10;
                }

                if (flag && (evenSum == oddSum))
                {
                    Console.Write(i + " ");
                }

            }
        }
    }
}
