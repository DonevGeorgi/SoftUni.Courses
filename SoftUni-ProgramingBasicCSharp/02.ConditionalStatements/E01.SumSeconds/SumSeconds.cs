using System;

namespace _01.SumSeconds
{
    internal class SumSeconds
    {
        static void Main(string[] args)
        {
            int firstP = int.Parse(Console.ReadLine());
            int secondP = int.Parse(Console.ReadLine());
            int thirdP = int.Parse(Console.ReadLine());

            int totalTime = firstP + secondP + thirdP;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            Console.WriteLine($"{minutes}:{seconds:D2}");
        }
    }
}