//Do not remove because of judge. Don't put in folders because of the namespace.
using E03.Telephony;
using P03.Telephony.Models.Classes;
using System;
using System.Linq;

namespace PersonInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        Smartphone smartphone = new();
        StationaryPhone stationaryPhone = new();

        string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].All(d => char.IsDigit(d)))
            {
                if (numbers[i].Length == 10)
                {
                    smartphone.Calling(numbers[i]);
                }
                else
                {
                    stationaryPhone.Calling(numbers[i]);
                }
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        for (int i = 0; i < websites.Length; i++)
        {
            if (!websites[i].Any(l => char.IsDigit(l)))
            {
                smartphone.Browsing(websites[i]);
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}