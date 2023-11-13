using System;
using System.Linq;

namespace E10.LadyBugs
{
    internal class LadyBugs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] field = new int[n];

            int[] indexWhereBugsAre = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            //Seting the field
            for (int i = 0; i < field.Length; i++)
            {
                for (int k = 0; k < indexWhereBugsAre.Length; k++)
                {
                    if (i == indexWhereBugsAre[k])
                    {
                        field[i] = 1;
                    }
                }

            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input
                    .Split(" ");

                int indexOf = int.Parse(inputArgs[0]);

                if (indexOf < 0 || indexOf >= field.Length)
                {
                    continue;
                }

                if (field[indexOf] == 0)
                {
                    continue;
                }

                string flySide = inputArgs[1];

                if (flySide == "right")
                {
                    int flight = int.Parse(inputArgs[2]);

                    // initializing movement
                    int movement = indexOf + flight;

                    //release start index
                    field[indexOf] = 0;

                    //move if is 1 and skip if is 0
                    while (movement >= 0 && movement < field.Length && field[movement] == 1)
                    {
                        movement += flight;
                    }

                    // check borders
                    if (movement < 0 || movement >= field.Length)
                    {
                        continue;
                    }

                    //initializing where ladybug go
                    field[movement] = 1;
                }
                else if (flySide == "left")
                {
                    int flight = int.Parse(inputArgs[2]);

                    flight *= -1;
                    int movement = indexOf + flight;

                    field[indexOf] = 0;

                    while (movement >= 0 && movement < field.Length && field[movement] == 1)
                    {
                        movement += flight;
                    }

                    if (movement < 0 || movement >= field.Length)
                    {
                        continue;
                    }

                    field[movement] = 1;
                }
            }

            Console.WriteLine(String.Join(" ", field));
        }
    }
}
