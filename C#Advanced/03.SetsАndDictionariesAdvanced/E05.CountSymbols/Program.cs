using System;
using System.Collections.Generic;

namespace P05.CountSymbolsTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols
                = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!symbols.ContainsKey(input[i]))
                {
                    symbols[input[i]] = 0;
                }

                symbols[input[i]]++;
            }

            foreach (var character in symbols)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
