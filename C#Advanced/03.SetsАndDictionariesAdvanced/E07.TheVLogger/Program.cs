using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace P07.TheVLogger
{
    internal class Program
    {
        static void Main()
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = commandArgs[0];

                if (commandArgs[1] == "joined")
                {
                    if (!vloggers.Any(x => x.Name == name))
                    {
                        Vlogger vlogger = new Vlogger(name);
                        vloggers.Add(vlogger);
                    }
                }
                else if (commandArgs[1] == "followed")
                {
                    string follower = commandArgs[2];

                    if (vloggers.Any(x => x.Name == name)
                        && name != follower
                        && vloggers.Any(x => x.Name == follower)
                        && !vloggers.Find(x => x.Name == name).SearchFollowing(follower))
                    {
                        vloggers.Find(x => x.Name == name).AddFollowing(follower);
                        vloggers.Find(x => x.Name == follower).AddFollowers(name);
                    }
                }
            }

            int counter = 1;
            bool firstIsPrinted = true;

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            foreach (var vlogger in vloggers.OrderByDescending(x => x.followers.Count).ThenBy(x => x.following.Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Name} : {vlogger.followers.Count} followers, {vlogger.following.Count} following");

                if (firstIsPrinted)
                {
                    foreach (var follower in vlogger.followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                firstIsPrinted = false;
                counter++;
            }
        }

        public class Vlogger
        {
            public Vlogger(string name)
            {
                Name = name;
                followers = new List<string>();
                following = new List<string>();
            }

            public string Name { get; set; }
            public List<string> followers { get; set; }
            public List<string> following { get; set; }

            public void AddFollowers(string name)
            {
                followers.Add(name);
            }

            public void AddFollowing(string name)
            {
                following.Add(name);
            }

            public bool SearchFollowing(string name)
            {
                if (following.Contains(name))
                {
                    return true;
                }

                return false;
            }
        }

    }
}
