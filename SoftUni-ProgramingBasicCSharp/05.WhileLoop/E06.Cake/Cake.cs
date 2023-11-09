using System;

namespace Task06.Cake
{
    internal class Cake
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int cakeSize = lenght * width;

            while (cakeSize > 0)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    break;
                }

                int pieceSize = int.Parse(input);

                cakeSize -= pieceSize;
            }

            if (cakeSize >= 0)
            {
                Console.WriteLine($"{cakeSize} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {MathF.Abs(cakeSize)} pieces more.");
            }

        }
    }
}
