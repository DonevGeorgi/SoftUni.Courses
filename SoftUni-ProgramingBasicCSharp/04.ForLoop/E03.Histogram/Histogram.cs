using System;

namespace ConsoleApp1
{
    internal class Histogram
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1++;
                }
                else if (num >= 200 && num < 400)
                {
                    p2++;
                }
                else if (num >= 400 && num < 600)
                {
                    p3++;
                }
                else if (num >= 600 && num < 800)
                {
                    p4++;
                }
                else if (num >= 800)
                {
                    p5++;
                }
            }

            double finalP1 = ((double)p1 / n) * 100;
            double finalP2 = ((double)p2 / n) * 100;
            double finalP3 = ((double)p3 / n) * 100;
            double finalP4 = ((double)p4 / n) * 100;
            double finalP5 = ((double)p5 / n) * 100;

            Console.WriteLine($"{finalP1:F2}%");
            Console.WriteLine($"{finalP2:F2}%");
            Console.WriteLine($"{finalP3:F2}%");
            Console.WriteLine($"{finalP4:F2}%");
            Console.WriteLine($"{finalP5:F2}%");
        }
    }
}