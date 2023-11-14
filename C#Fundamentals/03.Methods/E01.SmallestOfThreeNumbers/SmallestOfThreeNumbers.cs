using System;

namespace E01.SmallestOfThreeNumbers
{
    internal class SmallestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            //Input
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            //Using Method
            int smallestNumber = SmallestOfThreeNums(numberOne, numberTwo, numberThree);

            //Output
            Console.WriteLine($"{smallestNumber}");
        }

        static int SmallestOfThreeNums(int numOne, int numTwo, int numThree)
        {
            if (numOne < numTwo && numOne < numThree)
            {
                return numOne;
            }
            else if (numTwo < numOne && numTwo < numThree)
            {
                return numTwo;
            }
            else
            {
                return numThree;
            }
        }
    }
}
