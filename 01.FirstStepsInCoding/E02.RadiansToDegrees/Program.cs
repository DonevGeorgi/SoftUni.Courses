using System;

namespace E02.RadiansToDegrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double angle = double.Parse(Console.ReadLine());

            Console.WriteLine(angle * 180 / Math.PI);
        }
    }
}
