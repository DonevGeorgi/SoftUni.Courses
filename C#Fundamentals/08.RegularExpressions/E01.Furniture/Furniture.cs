using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01.Furniture
{
    internal class Furniture
    {
        static void Main()
        {
            string patern = @"^>>(?<furniture>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)(\.\d+)?$";
            Regex regex = new Regex(patern);

            List<string> furnitures = new List<string>();
            decimal totalPrice = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string furnitureName = match.Groups["furniture"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal quantity = decimal.Parse(match.Groups["quantity"].Value);

                    furnitures.Add(furnitureName);

                    totalPrice += quantity * price;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var furniture in furnitures)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
