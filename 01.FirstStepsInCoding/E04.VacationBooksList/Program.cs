using System;

namespace E04.VacationBooksList
{
    internal class Program
    {
        static void Main()
        {
            int pageNum = int.Parse(Console.ReadLine());
            int pagePerHour = int.Parse(Console.ReadLine());
            int dayCount = int.Parse(Console.ReadLine());

            Console.WriteLine((pageNum / pagePerHour) / dayCount);
        }
    }
}
