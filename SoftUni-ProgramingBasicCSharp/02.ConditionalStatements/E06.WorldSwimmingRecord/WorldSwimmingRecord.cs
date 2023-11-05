using System;

namespace _06.WorldSwimmingRecord
{
    internal class WorldSwimmingRecord
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timePerMetersInSeconds = double.Parse(Console.ReadLine());

            double timeForDistance = distanceInMeters * timePerMetersInSeconds;

            double timeDelayed = Math.Floor(distanceInMeters / 15);

            double deleyTime = timeDelayed * 12.5;

            double totalTime = timeForDistance + deleyTime;

            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTime - recordInSeconds:F2} seconds slower.");
            }
        }
    }
}
