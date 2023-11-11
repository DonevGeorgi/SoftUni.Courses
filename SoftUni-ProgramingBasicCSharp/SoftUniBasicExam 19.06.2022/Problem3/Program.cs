using System;

namespace Problem3
{
    internal class Program
    {
        static void Main()
        {
            int daysBooked = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string review = Console.ReadLine();

            double totalPrice = 0;
            daysBooked--;

            if (daysBooked < 10)
            {
                if (roomType == "room for one person")
                {
                    totalPrice = daysBooked * 18.00;
                }
                else if (roomType == "apartment")
                {
                    totalPrice = daysBooked * 25.00;
                    double discount = totalPrice * 0.30;
                    totalPrice -= discount;
                }
                else if (roomType == "president apartment")
                {
                    totalPrice = daysBooked * 35.00;
                    double discount = totalPrice * 0.10;
                    totalPrice -= discount;
                }
            }
            else if (daysBooked >= 10 && daysBooked < 15)
            {
                if (roomType == "room for one person")
                {
                    totalPrice = daysBooked * 18.00;
                }
                else if (roomType == "apartment")
                {
                    totalPrice = daysBooked * 25.00;
                    double discount = totalPrice * 0.35;
                    totalPrice -= discount;
                }
                else if (roomType == "president apartment")
                {
                    totalPrice = daysBooked * 35.00;
                    double discount = totalPrice * 0.15;
                    totalPrice -= discount;
                }
            }
            else if (daysBooked > 15)
            {
                if (roomType == "room for one person")
                {
                    totalPrice = daysBooked * 18.00;
                }
                else if (roomType == "apartment")
                {
                    totalPrice = daysBooked * 25.00;
                    double discount = totalPrice * 0.50;
                    totalPrice -= discount;
                }
                else if (roomType == "president apartment")
                {
                    totalPrice = daysBooked * 35.00;
                    double discount = totalPrice * 0.20;
                    totalPrice -= discount;
                }
            }

            if (review == "positive")
            {
                double discount = totalPrice * 0.25;
                totalPrice += discount;
            }
            else if (review == "negative")
            {
                double discount = totalPrice * 0.10;
                totalPrice -= discount;
            }

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
