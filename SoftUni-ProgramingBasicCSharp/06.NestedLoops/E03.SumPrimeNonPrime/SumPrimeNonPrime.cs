using System;

namespace Task03.SumPrimeNonPrime
{
    internal class SumPrimeNonPrime
    {
        static void Main()
        {
            int compoundsSum = 0;
            int primesSum = 0;

            string input = "";

            while ((input = Console.ReadLine()) != "stop")
            {
                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool numIsPrime = true;

                for (int diveder = 2; diveder < number; diveder++)
                {
                    int result = number % diveder;

                    if (result == 0)
                    {
                        compoundsSum += number;
                        numIsPrime = false;
                        break;
                    }
                }

                if (numIsPrime)
                {
                    primesSum += number;
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primesSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {compoundsSum}");
        }
    }
}
