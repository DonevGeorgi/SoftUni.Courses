using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.CardsGame
{
    internal class CardsGame
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int firstNumberP1 = 0;
            int secondNumberP1 = 0;

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                firstNumberP1 = firstPlayer[0];
                secondNumberP1 = secondPlayer[0];

                if (firstPlayer[0] > secondPlayer[0])
                {
                    secondPlayer.RemoveAt(0);
                    firstPlayer.RemoveAt(0);
                    firstPlayer.Add(secondNumberP1);
                    firstPlayer.Add(firstNumberP1);

                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                    secondPlayer.Add(firstNumberP1);
                    secondPlayer.Add(secondNumberP1);
                }
                else if (firstPlayer[0] == secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }

            if (secondPlayer.Count <= 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else if (firstPlayer.Count <= 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
    }
}
