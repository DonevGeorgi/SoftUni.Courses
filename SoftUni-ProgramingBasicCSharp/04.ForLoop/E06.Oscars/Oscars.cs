using System;

namespace Task06.Oscars
{
    internal class Oscars
    {
        static void Main()
        {
            string actorName = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int countOfTheJudge = int.Parse(Console.ReadLine());

            double finalPoints = pointsFromAcademy;
            double finalPointOfTheJudge = 0;

            for (int i = 1; i <= countOfTheJudge; i++)
            {
                string nameOfTheJudge = Console.ReadLine();
                double pointOfTheJudge = double.Parse(Console.ReadLine());

                finalPointOfTheJudge = nameOfTheJudge.Length * pointOfTheJudge / 2;

                finalPoints += finalPointOfTheJudge;

                if (finalPoints > 1250.5)
                {
                    break;
                }
            }


            if (finalPoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {finalPoints:f1}!");
            }
            else
            {
                double neededPoints = 1250.5 - finalPoints;
                Console.WriteLine($"Sorry, {actorName} you need {neededPoints:f1} more!");
            }
        }
    }
}
