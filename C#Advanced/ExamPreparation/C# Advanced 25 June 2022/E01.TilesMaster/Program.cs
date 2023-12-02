using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> whiteTileArea = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Queue<int> greyTileArea = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Dictionary<string, int> tileUsed =
                new Dictionary<string, int>();

            tileUsed["Countertop"] = 0;
            tileUsed["Floor"] = 0;
            tileUsed["Oven"] = 0;
            tileUsed["Sink"] = 0;
            tileUsed["Wall"] = 0;

            while (true)
            {
                if (whiteTileArea.Peek() == greyTileArea.Peek())
                {
                    int largerTile = whiteTileArea.Peek() + greyTileArea.Peek();

                    switch (largerTile)
                    {
                        case 40:

                            whiteTileArea.Pop();
                            greyTileArea.Dequeue();
                            tileUsed["Sink"]++;

                            break;

                        case 50:

                            whiteTileArea.Pop();
                            greyTileArea.Dequeue();
                            tileUsed["Oven"]++;

                            break;

                        case 60:

                            whiteTileArea.Pop();
                            greyTileArea.Dequeue();
                            tileUsed["Countertop"]++;

                            break;

                        case 70:

                            whiteTileArea.Pop();
                            greyTileArea.Dequeue();
                            tileUsed["Wall"]++;

                            break;

                        default:

                            whiteTileArea.Pop();
                            greyTileArea.Dequeue();
                            tileUsed["Floor"]++;

                            break;
                    }
                }
                else
                {
                    whiteTileArea.Push(whiteTileArea.Pop() / 2);
                    greyTileArea.Enqueue(greyTileArea.Dequeue());
                }

                if (!whiteTileArea.Any() && !greyTileArea.Any())
                {
                    Console.WriteLine("White tiles left: none");
                    Console.WriteLine("Grey tiles left: none");
                    break;
                }

                if (!whiteTileArea.Any())
                {
                    Console.WriteLine("White tiles left: none");
                    Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTileArea)}");
                    break;
                }

                if (!greyTileArea.Any())
                {
                    Console.WriteLine("Grey tiles left: none");
                    Console.WriteLine($"White tiles left: {string.Join(", ", whiteTileArea)}");
                    break;
                }
            }

            foreach (var tile in tileUsed.OrderByDescending(x => x.Value))
            {
                if (tile.Value > 0)
                {
                    Console.WriteLine($"{tile.Key}: {tile.Value}");
                }
            }
        }
    }
}
