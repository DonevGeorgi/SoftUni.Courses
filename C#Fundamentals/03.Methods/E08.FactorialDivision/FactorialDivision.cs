using System;

namespace E08.FactorialDivision
{
    internal class FactorialDivision
    {
        static void Main(string[] args)
        {
            //input
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());

            //Method for factoriel
            double factorielOfFirstNum = CalculatingFactoriel(firstNumber);
            double factorielOfSecNum = CalculatingFactoriel(secondNumber);

            //Output
            Console.WriteLine($"{factorielOfFirstNum / factorielOfSecNum:f2}");
        }

        static double CalculatingFactoriel(double num)
        {
            long factoriel = 1;

            for (int i = 1; i <= num; i++)
            {
                factoriel *= i;
            }

            return factoriel;
        }
    }
}
