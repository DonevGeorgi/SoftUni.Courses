using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.AppendArrays
{
    internal class AppendArrays
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine()
                .Split("|")
                .Reverse()
                .ToList();

            List<int> num = new List<int>();

            foreach (var ch in numbers)
            {
                num.AddRange(ch.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList()
                                     );
            }

            Console.WriteLine(string.Join(" ", num));
        }
    }
}
