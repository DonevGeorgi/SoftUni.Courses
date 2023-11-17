using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.SoftUniParking
{
    internal class SoftUniParking
    {
        static void Main()
        {
            Dictionary<string, string> registered =
                new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string nameOfTheClient = input[1];

                if (input[0] == "register")
                {
                    string licensePlateNum = input[2];

                    if (!registered.ContainsKey(nameOfTheClient))
                    {
                        registered[nameOfTheClient] = licensePlateNum;
                        Console.WriteLine($"{nameOfTheClient} registered {licensePlateNum} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registered[nameOfTheClient]}");
                    }
                }
                else if (input[0] == "unregister")
                {
                    if (registered.ContainsKey(nameOfTheClient))
                    {
                        registered.Remove(nameOfTheClient);
                        Console.WriteLine($"{nameOfTheClient} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {nameOfTheClient} not found");
                    }
                }
            }

            foreach (var client in registered)
            {
                Console.WriteLine($"{client.Key} => {client.Value}");
            }
        }
    }
}
