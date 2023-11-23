using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe
                = new Dictionary<string, Dictionary<string, int>>();

            InitializingDictionary(n, wardrobe);

            string[] serchedCloth = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            PrintingResult(wardrobe, serchedCloth);
        }

        static void InitializingDictionary(int n, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            for (int i = 0; i < n; i++)
            {
                string[] clothing = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string clothCoolor = clothing[0];

                if (!wardrobe.ContainsKey(clothCoolor))
                {
                    wardrobe[clothCoolor] = new Dictionary<string, int>();
                }

                for (int currCloth = 1; currCloth < clothing.Length; currCloth++)
                {
                    if (!wardrobe[clothCoolor].ContainsKey(clothing[currCloth]))
                    {
                        wardrobe[clothCoolor][clothing[currCloth]] = 0;
                    }

                    wardrobe[clothCoolor][clothing[currCloth]]++;
                }
            }
        }
        static void PrintingResult(Dictionary<string, Dictionary<string, int>> wardrobe, string[] serchedCloth)
        {
            foreach (var cloth in wardrobe)
            {
                Console.WriteLine($"{cloth.Key} clothes:");

                foreach (var item in cloth.Value)
                {

                    if (serchedCloth[0] == cloth.Key
                        && serchedCloth[1] == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
