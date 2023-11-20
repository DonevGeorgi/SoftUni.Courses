using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.KeyRevolver
{
    internal class KeyRevolver
    {
        static void Main()
        {
            int priceOfBullets = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> locks = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int money = int.Parse(Console.ReadLine());

            int counterForReload = 0;
            int shoots = 0;
            bool canReload = false;

            if (bullets.Count > sizeOfBarrel)
            {
                canReload = true;
            }

            while (true)
            {
                if (!locks.Any())
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${money - (shoots * priceOfBullets)}");
                    return;
                }

                if (!bullets.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
                shoots++;
                counterForReload++;

                if (bullets.Peek() <= locks.Peek())
                {
                    bullets.Pop();
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                }

                if (counterForReload == sizeOfBarrel && canReload && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    counterForReload = 0;
                }
            }
        }
    }
}
