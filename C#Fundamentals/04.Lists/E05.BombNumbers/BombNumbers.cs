using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.BombNumbers
{
    internal class BombNumbers
    {
        static void Main()
        {
            List<int> numberSec = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombNumAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (numberSec.Contains(bombNumAndPower[0]))
            {
                int index = 0;

                for (int i = 1; i <= bombNumAndPower[1]; i++)
                {
                    index = numberSec.IndexOf(bombNumAndPower[0]);

                    if (index + 1 >= numberSec.Count)
                    {
                        break;
                    }

                    numberSec.RemoveAt(index + 1);
                }

                for (int i = 1; i <= bombNumAndPower[1]; i++)
                {
                    index = numberSec.IndexOf(bombNumAndPower[0]);

                    if (index - 1 < 0)
                    {
                        break;
                    }

                    numberSec.RemoveAt(index - 1);
                }

                numberSec.Remove(bombNumAndPower[0]);
            }

            Console.WriteLine(numberSec.Sum());
        }
    }
}
