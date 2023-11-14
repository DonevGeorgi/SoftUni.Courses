using System;

namespace E05.AddAndSubtract
{
    internal class AddAndSubtract
    {
        static void Main(string[] args)
        {
            //Input
            int firstNimber = int.Parse(Console.ReadLine());
            int secondNimber = int.Parse(Console.ReadLine());
            int thirdNimber = int.Parse(Console.ReadLine());

            //Method for sum
            int finalNum = SumTheFirstAndSecondNum(firstNimber, secondNimber);

            //Method for subtrack
            finalNum = SubtrackThirdFromTheFirstTwo(finalNum, thirdNimber);

            //Output
            Console.WriteLine(finalNum);
        }

        static int SumTheFirstAndSecondNum(int firstNum, int secondNum)
        {
            int sum = firstNum + secondNum;
            return sum;
        }

        static int SubtrackThirdFromTheFirstTwo(int finalNum, int thirdNum)
        {
            finalNum -= thirdNum;
            return finalNum;
        }
    }
}
