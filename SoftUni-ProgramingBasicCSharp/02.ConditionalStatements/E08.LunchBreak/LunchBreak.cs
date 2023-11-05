using System;

namespace _08.LunchBreak
{
    internal class LunchBreak
    {
        static void Main(string[] args)
        {
            string nameOfShow = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int breakDuration = int.Parse(Console.ReadLine());

            double timeForLunch = breakDuration / 8.0;//Warning one of number have to be double
            double timeForRelax = breakDuration / 4.0;//Warning one of number have to be double

            double timeLeftFromBreak = breakDuration - timeForLunch - timeForRelax;

            if (timeLeftFromBreak >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {nameOfShow} and left with {Math.Ceiling(timeLeftFromBreak - episodeDuration)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {nameOfShow}, you need {Math.Ceiling(episodeDuration - timeLeftFromBreak)} more minutes.");
            }
        }
    }
}
