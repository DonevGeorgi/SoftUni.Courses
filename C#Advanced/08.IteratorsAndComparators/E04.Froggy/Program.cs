using System;
using System.Linq;
using P04.Froggy;

namespace P04.Froggy
{
    internal class Program
    {
        static void Main()
        {
            int[] stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Lake<int> lake = new(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
