using System;
using System.Text.RegularExpressions;

namespace P03.SoftUniBarIncome
{
    internal class SoftUniBarIncome
    {
        static void Main()
        {
            string patern = @"\%(?<custumer>[A-Z][a-z]+)\%[^\$|\||\%|\.]*?\<(?<product>\w+)\>[^\$|\||\%|\.]*?\|(?<count>\d+)\|[^\$|\||\%|\.]*?(?<price>\d+(\.\d+)?)\$";
            Regex regex = new Regex(patern);

            double totalPriceOfTheDay = 0;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    double priceOfOrder = double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["count"].Value);
                    Console.WriteLine($"{match.Groups["custumer"].Value}: {match.Groups["product"].Value} - {priceOfOrder:f2}");

                    totalPriceOfTheDay += priceOfOrder;
                }
            }

            Console.WriteLine($"Total income: {totalPriceOfTheDay:f2}");
        }
    }
}
