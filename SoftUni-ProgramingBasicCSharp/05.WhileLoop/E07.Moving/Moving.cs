using System;

namespace Task07.Moving
{
    internal class Moving
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int volume = width * lenght * height;

            while (volume > 0)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                int boxes = int.Parse(input);

                volume -= boxes;
            }

            if (volume >= 0)
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }
        }
    }
}
