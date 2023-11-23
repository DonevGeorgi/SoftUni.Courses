using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers
                = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currNum))
                {
                    numbers[currNum] = 0;
                }

                numbers[currNum]++;
            }

            Console.WriteLine(numbers.Single(x => x.Value % 2 == 0).Key);
        }
    }
}
