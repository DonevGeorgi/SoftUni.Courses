using System;

namespace Task08.SkiTrip
{
    internal class SkiTrip
    {
        static void Main()
        {
            int bookedDays = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string grade = Console.ReadLine();

            double price = 0;
            double discount = 0;
            double bonus = 0;

            bookedDays = bookedDays - 1;

            if (typeOfRoom == "room for one person")
            {
                price = bookedDays * 18;
            }
            else if (typeOfRoom == "apartment")
            {
                price = bookedDays * 25;

                if (bookedDays < 10)
                {
                    discount = price * 0.30;
                    price -= discount;
                }
                else if (bookedDays >= 10 && bookedDays <= 15)
                {
                    discount = price * 0.350;
                    price -= discount;
                }
                else if (bookedDays > 15)
                {
                    discount = price * 0.50;
                    price -= discount;
                }
            }
            else if (typeOfRoom == "president apartment")
            {
                price = bookedDays * 35;

                if (bookedDays < 10)
                {
                    discount = price * 0.10;
                    price -= discount;
                }
                else if (bookedDays >= 10 && bookedDays <= 15)
                {
                    discount = price * 0.15;
                    price -= discount;
                }
                else if (bookedDays > 15)
                {
                    discount = price * 0.20;
                    price -= discount;
                }
            }

            if (grade == "positive")
            {
                bonus = price * 0.25;
                price += bonus;
            }
            else if (grade == "negative")
            {
                discount = price * 0.10;
                price -= discount;
            }

            Console.WriteLine($"{price:f2}");

        }
    }
}
