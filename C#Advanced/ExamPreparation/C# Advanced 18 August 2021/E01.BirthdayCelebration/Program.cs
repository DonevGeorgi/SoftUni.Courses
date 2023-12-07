using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guest = new Queue<int>(
               Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToArray());

            Stack<int> plate = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());


            int wastedFood = 0;

            while (true)
            {
                int currGuest = guest.Peek();
                int currPlate = plate.Peek();

                if (currPlate - currGuest > 0)
                {
                    wastedFood += currPlate - currGuest;

                    plate.Pop();
                    guest.Dequeue();
                }
                else
                {
                    plate.Pop();

                    currGuest -= currPlate;

                    if (currGuest == 0)
                    {
                        guest.Dequeue();
                    }

                    while (currGuest > 0)
                    {
                        currGuest -= plate.Peek();

                        if (currGuest <= 0)
                        {
                            wastedFood += Math.Abs(currGuest);
                            plate.Pop();
                            guest.Dequeue();
                        }
                        else
                        {
                            plate.Pop();
                        }
                    }
                }

                if (!plate.Any() || !guest.Any())
                {
                    break;
                }
            }

            if (!plate.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guest)}");
            }

            if (!guest.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plate)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}

