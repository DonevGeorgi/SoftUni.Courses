using System;
using System.Linq;

namespace P03.TheAngryCat
{
    internal class TheAngryCat
    {
        static void Main()
        {
            //Input
            string[] friendsList = Console.ReadLine()
                .Split(", ")
                .ToArray();

            int countOfBlacklistedNames = 0;
            int countOfLostlistedNames = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "Blacklist")
                {
                    string name = inputArgs[1];

                    bool notFound = true;

                    for (int i = 0; i < friendsList.Length; i++)
                    {
                        if (friendsList[i] == name)
                        {
                            notFound = false;
                            friendsList[i] = "Blacklisted";
                            Console.WriteLine($"{name} was blacklisted.");
                            break;
                        }
                    }

                    if (notFound)
                    {
                        Console.WriteLine($"{name} was not found.");
                    }

                }
                else if (inputArgs[0] == "Error")
                {
                    int index = int.Parse(inputArgs[1]);

                    if (index < 0 || index >= friendsList.Length || friendsList[index] == "Blacklisted" || friendsList[index] == "Lost")
                    {
                        continue;
                    }

                    Console.WriteLine($"{friendsList[index]} was lost due to an error.");
                    friendsList[index] = "Lost";

                }
                else if (inputArgs[0] == "Change")
                {
                    int index = int.Parse((inputArgs[1]));
                    string newName = inputArgs[2];

                    if (index < 0 || index >= friendsList.Length)
                    {
                        continue;
                    }

                    Console.WriteLine($"{friendsList[index]} changed his username to {newName}.");
                    friendsList[index] = newName;

                }
            }

            for (int i = 0; i < friendsList.Length; i++)
            {
                if (friendsList[i] == "Blacklisted")
                {
                    countOfBlacklistedNames++;
                }
                else if (friendsList[i] == "Lost")
                {
                    countOfLostlistedNames++;
                }
            }

            Console.WriteLine($"Blacklisted names: {countOfBlacklistedNames}");
            Console.WriteLine($"Lost names: {countOfLostlistedNames}");
            Console.WriteLine(string.Join(" ", friendsList));
        }
    }
}