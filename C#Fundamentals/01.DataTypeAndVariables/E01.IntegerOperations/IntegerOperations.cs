using System;

namespace P01.IntegerOperations
{
    internal class IntegerOperations
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            long addResult = (long)firstNum + secondNum;
            long divisionResult = addResult / thirdNum;
            long multiplyingResult = divisionResult * fourthNum;

            Console.WriteLine($"{multiplyingResult}");
        }
    }
}
