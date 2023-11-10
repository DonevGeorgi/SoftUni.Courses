using System;

namespace Task06.CinemaTickets
{
    internal class CinemaTickets
    {
        static void Main()
        {
            int totalTicketsOfTheDay = 0;

            int studentTickets = 0;
            int kidTickets = 0;
            int standartTickets = 0;

            string input = "";

            while (input != "Finish")
            {
                input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }

                string filmTitle = input;

                int freeSpaceInTheSalon = int.Parse(Console.ReadLine());

                int currentAvailableSeats = freeSpaceInTheSalon;

                string ticketType = "";

                int ticketsSoldForFilm = 0;

                while (ticketType != "Ënd" && currentAvailableSeats > 0)
                {
                    ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    ticketsSoldForFilm++;
                    totalTicketsOfTheDay++;
                    currentAvailableSeats--;

                    switch (ticketType)
                    {
                        case "standard":
                            standartTickets++;
                            break;
                        case "student":
                            studentTickets++;
                            break;
                        case "kid":
                            kidTickets++;
                            break;
                    }
                }

                double percentageFull = ticketsSoldForFilm / (freeSpaceInTheSalon * 1.0) * 100;
                Console.WriteLine($"{filmTitle} - {percentageFull:f2}% full.");

            }

            Console.WriteLine($"Total tickets: {totalTicketsOfTheDay}");

            double percStudents = studentTickets / (totalTicketsOfTheDay * 1.0) * 100;
            Console.WriteLine($"{percStudents:f2}% student tickets.");

            double percStandarts = standartTickets / (totalTicketsOfTheDay * 1.0) * 100;
            Console.WriteLine($"{percStandarts:f2}% standard tickets.");

            double percKids = kidTickets / (totalTicketsOfTheDay * 1.0) * 100;
            Console.WriteLine($"{percKids:f2}% kids tickets.");
        }
    }
}
