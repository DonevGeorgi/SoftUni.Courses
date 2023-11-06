using System;

namespace Task07.HotelRoom
{
    internal class HotelRoom
    {
        static void Main()
        {
            string month = Console.ReadLine();
            int numberOfBookedNights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;
            double discount = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = numberOfBookedNights * 50;
                apartmentPrice = numberOfBookedNights * 65;

                if (numberOfBookedNights > 7 && numberOfBookedNights <= 14)
                {
                    discount = studioPrice * 0.05;
                    studioPrice -= discount;
                }
                else if (numberOfBookedNights > 14)
                {
                    discount = studioPrice * 0.30;
                    studioPrice -= discount;

                    discount = apartmentPrice * 0.10;
                    apartmentPrice -= discount;
                }

            }
            else if (month == "June" || month == "September")
            {
                studioPrice = numberOfBookedNights * 75.20;
                apartmentPrice = numberOfBookedNights * 68.70;

                if (numberOfBookedNights > 14)
                {
                    discount = studioPrice * 0.20;
                    studioPrice -= discount;

                    discount = apartmentPrice * 0.10;
                    apartmentPrice -= discount;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = numberOfBookedNights * 76;
                apartmentPrice = numberOfBookedNights * 77;

                if (numberOfBookedNights > 14)
                {
                    discount = apartmentPrice * 0.10;
                    apartmentPrice -= discount;
                }
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
