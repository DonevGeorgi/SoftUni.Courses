using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TruckTour
{
    internal class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> fuel = new Queue<int>();
            Queue<int> kilometers = new Queue<int>();

            int firstWiningIndex = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                fuel.Enqueue(input[0]);
                kilometers.Enqueue(input[1]);
            }

            while (true)
            {
                int amountOfFuel = 0;
                bool isFist = true;

                for (int i = 0; i < n; i++)
                {
                    int currFuel = fuel.Dequeue();
                    int currKilometers = kilometers.Dequeue();

                    amountOfFuel += currFuel;

                    if (amountOfFuel < currKilometers)
                    {
                        isFist = false;
                    }

                    amountOfFuel -= currKilometers;

                    fuel.Enqueue(currFuel);
                    kilometers.Enqueue(currKilometers);
                }

                if (isFist)
                {
                    break;
                }

                firstWiningIndex++;

                fuel.Enqueue(fuel.Dequeue());
                kilometers.Enqueue(kilometers.Dequeue());
            }

            Console.WriteLine(firstWiningIndex);
        }
    }
}
