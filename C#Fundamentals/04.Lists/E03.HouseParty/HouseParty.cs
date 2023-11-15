using System;
using System.Collections.Generic;

namespace E03.HouseParty
{
    internal class HouseParty
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(' ');

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];

                    bool isGoing = false;

                    for (int k = 0; k < guestList.Count; k++)
                    {
                        if (guestList[k] == name)
                        {
                            Console.WriteLine($"{name} is already in the list!");
                            isGoing = true;
                            break;
                        }
                    }

                    if (isGoing)
                    {
                        continue;
                    }

                    guestList.Add(name);

                }
                else if (inputArgs.Length == 4)
                {
                    string name = inputArgs[0];

                    bool isRemoved = false;

                    for (int k = 0; k < guestList.Count; k++)
                    {
                        if (guestList[k] == name)
                        {
                            guestList.RemoveAt(k);
                            isRemoved = true;
                            break;
                        }
                    }

                    if (isRemoved)
                    {
                        continue;
                    }

                    Console.WriteLine($"{name} is not in the list!");
                }
            }

            foreach (var name in guestList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
