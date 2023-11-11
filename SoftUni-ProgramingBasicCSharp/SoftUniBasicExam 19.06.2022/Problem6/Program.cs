using System;

namespace Problem6
{
    internal class Program
    {
        static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int cooldown = 0;

            for (int ch1 = k; ch1 <= 8; ch1++)
            {
                for (int ch2 = 9; ch2 >= l; ch2--)
                {
                    for (int ch3 = m; ch3 <= 8; ch3++)
                    {
                        for (int ch4 = 9; ch4 >= n; ch4--)
                        {
                            if (cooldown < 6)
                            {
                                if (ch1 % 2 == 0 && ch2 % 2 != 0 && ch3 % 2 ==0 && ch4 % 2 != 0)
                                {
                                    if (ch1 != ch3 || ch2 != ch4)
                                    {
                                        Console.WriteLine($"{ch1}{ch2} - {ch3}{ch4}");
                                        cooldown++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cannot change the same player.");
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
