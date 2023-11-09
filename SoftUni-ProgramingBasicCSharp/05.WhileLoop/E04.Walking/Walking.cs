using System;

namespace Task04.Walking
{
    internal class Walking
    {
        static void Main()
        {
            int totalSteps = 0;

            while (totalSteps < 10000)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    totalSteps += int.Parse(Console.ReadLine());
                    break;
                }

                int steps = int.Parse(input);

                totalSteps += steps;
            }

            if (totalSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
            }
        }
    }
}
