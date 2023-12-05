using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Stack<int> carbon = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Dictionary<string, int> swords = new Dictionary<string, int>();

            swords["Broadsword"] = 0;
            swords["Sabre"] = 0;
            swords["Katana"] = 0;
            swords["Shamshir"] = 0;
            swords["Gladius"] = 0;

            int forgedSwords = 0;

            while (true)
            {
                int matrial = steel.Peek() + carbon.Peek();

                switch (matrial)
                {
                    case 70:

                        swords["Gladius"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        forgedSwords++;

                        break;

                    case 80:

                        swords["Shamshir"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        forgedSwords++;

                        break;

                    case 90:

                        swords["Katana"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        forgedSwords++;

                        break;

                    case 110:

                        swords["Sabre"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        forgedSwords++;

                        break;

                    case 150:

                        swords["Broadsword"]++;
                        steel.Dequeue();
                        carbon.Pop();
                        forgedSwords++;

                        break;

                    default:

                        steel.Dequeue();
                        carbon.Push(carbon.Pop() + 5);

                        break;
                }

                if (!steel.Any() || !carbon.Any())
                {
                    break;
                }
            }

            if (forgedSwords == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {forgedSwords} swords.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swords.OrderBy(x => x.Key))
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
