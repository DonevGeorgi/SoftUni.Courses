using System;

namespace E08.BasketballEquipment
{
    internal class Program
    {
        static void Main()
        {
            int earlySub = int.Parse(Console.ReadLine());

            double shoes = earlySub - (earlySub * 0.40);
            double suit = shoes - (shoes * 0.20);
            double ball = suit * 0.25;
            double accessory = ball * 0.20;

            Console.WriteLine(earlySub + shoes + suit + ball + accessory);
        }
    }
}