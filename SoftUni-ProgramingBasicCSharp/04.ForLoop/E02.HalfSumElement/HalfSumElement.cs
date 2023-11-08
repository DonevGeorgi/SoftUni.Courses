using System;

namespace ConsoleApp1
{
    internal class HalfSumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int maxNum = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                sum += num;

                if (num > maxNum)
                {
                    maxNum = num;
                }
            }

            int sumWithoutMaxNum = sum - maxNum;

            if (maxNum == sumWithoutMaxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNum - sumWithoutMaxNum)}");
            }
        }
    }
}
