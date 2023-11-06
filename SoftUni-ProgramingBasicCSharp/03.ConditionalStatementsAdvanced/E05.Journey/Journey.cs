using System;

namespace Task05.Jorney
{
    internal class Jorney
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double startMoney = budget;
            double discount = 0;
            string destination = "";
            string typeOfBuilding = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    discount = budget * 0.30;
                    budget -= discount;

                    typeOfBuilding = "Camp";
                }
                else if (season == "winter")
                {
                    discount = budget * 0.70;
                    budget -= discount;

                    typeOfBuilding = "Hotel";
                }
            }
            else if (budget >= 100 && budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    discount = budget * 0.40;
                    budget -= discount;

                    typeOfBuilding = "Camp";
                }
                else if (season == "winter")
                {
                    discount = budget * 0.80;
                    budget -= discount;

                    typeOfBuilding = "Hotel";
                }
            }
            else if (budget >= 1000)
            {
                destination = "Europe";

                discount = budget * 0.90;
                budget -= discount;

                typeOfBuilding = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfBuilding} - {startMoney - budget:f2}");

        }
    }
}
