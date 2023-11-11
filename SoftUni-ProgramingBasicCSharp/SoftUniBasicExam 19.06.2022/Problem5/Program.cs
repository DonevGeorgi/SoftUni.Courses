using System;

namespace Problem5
{
    internal class Program
    {
        static void Main()
        {
            bool cooldown = false;

            int goals = 0;

            string currentBest = "";

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "END")
                {
                    break;
                }

                int scoredGoal = int.Parse(Console.ReadLine());

                cooldown = false;

                if (scoredGoal >= 3)
                {
                    cooldown = true;
                }

                if (scoredGoal > goals)
                {
                    goals = scoredGoal;
                    currentBest = name;
                }

                if (scoredGoal >= 10)
                {
                    break;
                }
            }

            Console.WriteLine($"{currentBest} is the best player!");

            if (cooldown == true)
            {
                Console.WriteLine($"He has scored {goals} goals and made a hat-trick !!!");
            }
            else if (cooldown == false)
            {
                Console.WriteLine($"He has scored {goals} goals.");
            }
        }
    }
}
