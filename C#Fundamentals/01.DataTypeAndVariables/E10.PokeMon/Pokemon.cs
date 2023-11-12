using System;

namespace P10.Pokemon
{
    internal class Pokemon
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int pokeCounter = 0;

            int nCopy = n;
            nCopy /= 2;

            while (true)
            {
                if (n >= m)
                {
                    n -= m;
                    pokeCounter++;
                }
                else
                {
                    break;
                }

                if (n == nCopy && y != 0)
                {
                    n /= y;
                }

            }

            Console.WriteLine(n);
            Console.WriteLine(pokeCounter);
        }
    }
}
