using System;

namespace _03.TimeMinutes
{
    internal class TimeMinutes
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int bonus = 15;

            minutes += bonus;

            if (minutes > 59)
            {
                hours += 1;

                if (hours > 23)
                {
                    hours = 0;
                }

                minutes -= 60;
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
