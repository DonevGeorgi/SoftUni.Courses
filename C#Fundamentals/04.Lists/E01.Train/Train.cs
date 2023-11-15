using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.Train
{
    internal class Train
    {
        static void Main()
        {
            List<int> train = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapasityOfTheWagon = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "Add")
                {
                    int addWagon = int.Parse(inputArgs[1]);

                    train.Add(addWagon);
                }
                else
                {
                    int passengers = int.Parse(inputArgs[0]);

                    for (int i = 0; i < train.Count; i++)
                    {
                        if ((train[i] + passengers) > maxCapasityOfTheWagon)
                        {
                            continue;
                        }
                        else if ((train[i] + passengers) <= maxCapasityOfTheWagon)
                        {
                            train[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
