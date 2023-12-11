using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            Queue<int> armorPlates = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            int count = 1;
            int currWave = 1;

            while (true)
            {
                Stack<int> orcs = new Stack<int>(
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray());

                if (count == 3)
                {
                    count = 0;
                    armorPlates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcs.Any())
                {
                    int currOrc = orcs.Peek();
                    int currPlate = armorPlates.Peek();

                    if (currOrc > currPlate)
                    {
                        armorPlates.Dequeue();
                        orcs.Push(orcs.Pop() - currPlate);
                    }
                    else if (currPlate > currOrc)
                    {
                        orcs.Pop();
                        armorPlates.Enqueue(armorPlates.Dequeue() - currOrc);

                        for (int i = 0; i < armorPlates.Count - 1; i++)
                        {
                            armorPlates.Enqueue(armorPlates.Dequeue());
                        }
                    }
                    else
                    {
                        orcs.Pop();
                        armorPlates.Dequeue();
                    }

                    if (!armorPlates.Any())
                    {
                        break;
                    }
                }

                if (currWave == numberOfWaves || !armorPlates.Any())
                {
                    if (!orcs.Any())
                    {
                        Console.WriteLine("The people successfully repulsed the orc's attack.");
                        Console.WriteLine($"Plates left: {string.Join(", ", armorPlates)}");
                        return;
                    }

                    if (!armorPlates.Any())
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                        return;
                    }
                }

                currWave++;
                count++;

            }

        }
    }
}

