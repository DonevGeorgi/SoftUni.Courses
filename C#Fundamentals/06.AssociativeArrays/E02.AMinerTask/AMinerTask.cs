using System;
using System.Collections.Generic;

namespace P02.AMinerTask
{
    internal class AMinerTask
    {
        static void Main()
        {
            Dictionary<string, int> resources =
                new Dictionary<string, int>();

            string input = string.Empty;

            int count = 0;
            string lastInput = string.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                count++;

                if (count % 2 == 1)
                {
                    if (!resources.ContainsKey(input))
                    {
                        resources.Add(input, 0);
                    }
                }
                else if (count % 2 == 0)
                {
                    if (resources.ContainsKey(lastInput))
                    {
                        resources[lastInput] += int.Parse(input);
                    }
                }

                lastInput = input;
            }

            foreach (var resorce in resources)
            {
                Console.WriteLine($"{resorce.Key} -> {resorce.Value}");
            }
        }
    }
}
