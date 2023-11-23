using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P02.SetsOfElements
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int m = input[1];

            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                setN.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                setM.Add(int.Parse(Console.ReadLine()));
            }

            setN.IntersectWith(setM);

            Console.Write(string.Join(' ', setN));
        }
    }
}
