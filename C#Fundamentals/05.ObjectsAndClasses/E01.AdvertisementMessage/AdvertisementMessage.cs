using System;
using System.Collections.Generic;

namespace E01.AdvertisementMessage
{
    internal class AdvertisementMessage
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] phrases = {"Excellent product.","Such a great product.",
                "I always use that product.",
                "Best product of its category.", "Exceptional product.",
                "I can't live without this product."};

            string[] events = { "Now I feel good.",
                "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"};

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int indexPhrase = random.Next(0, phrases.Length);
                int indexEvents = random.Next(0, events.Length);
                int indexAuthors = random.Next(0, authors.Length);
                int indexCities = random.Next(0, cities.Length);

                Console.WriteLine($"{phrases[indexPhrase]} {events[indexEvents]} {authors[indexAuthors]} – {cities[indexCities]}.");
            }
        }
    }
}
