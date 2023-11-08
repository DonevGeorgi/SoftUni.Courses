using System;

namespace Task08.TennisRanklist
{
    internal class TennisRanklist
    {
        static void Main()
        {
            int tournamentPlayed = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int points = startingPoints;
            double wins = 0;

            for (int i = 1; i <= tournamentPlayed; i++)
            {
                string finalStage = Console.ReadLine();

                if (finalStage == "W")
                {
                    points += 2000;
                    wins++;
                }
                else if (finalStage == "F")
                {
                    points += 1200;
                }
                else if (finalStage == "SF")
                {
                    points += 720;
                }
            }

            double averagePoints = (points - startingPoints) / (double)tournamentPlayed;
            double winRate = (wins / tournamentPlayed) * 100;

            Console.WriteLine("Final points: " + points);
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{winRate:F2}%");
        }
    }
}
