using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.ForceBook
{
    internal class ForceBook
    {
        static void Main()
        {
            SortedDictionary<string, SortedSet<string>> sidesUsers
                = new SortedDictionary<string, SortedSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] inputArgs = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = inputArgs[0];
                    string user = inputArgs[1];

                    if (!sidesUsers.Values.Any(x => x.Contains(user)))
                    {
                        if (!sidesUsers.ContainsKey(side))
                        {
                            sidesUsers.Add(side, new SortedSet<string>());
                        }

                        sidesUsers[side].Add(user);
                    }
                }
                else
                {
                    string[] commandArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string side = commandArgs[1];
                    string user = commandArgs[0];

                    foreach (var sideUsers in sidesUsers)
                    {
                        if (sideUsers.Value.Contains(user))
                        {
                            sideUsers.Value.Remove(user);
                            break;
                        }
                    }

                    if (!sidesUsers.ContainsKey(side))
                    {
                        sidesUsers.Add(side, new SortedSet<string>());
                    }

                    sidesUsers[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            Dictionary<string, SortedSet<string>> orderedSidesUsers = sidesUsers
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(key => key.Key, value => value.Value);

            foreach (var sideUsers in orderedSidesUsers)
            {
                if (sideUsers.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {sideUsers.Key}, Members: {sideUsers.Value.Count}");

                    foreach (var user in sideUsers.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }

    }
}
