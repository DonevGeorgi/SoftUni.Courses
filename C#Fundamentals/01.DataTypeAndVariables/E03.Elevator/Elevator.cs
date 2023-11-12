using System;

namespace P03.Elevator
{
    internal class Elevator
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int elevatorCapasity = int.Parse(Console.ReadLine());

            double courseNeeded = Math.Ceiling((double)persons / elevatorCapasity);

            Console.WriteLine($"{courseNeeded}");
        }
    }
}
