using System;

namespace Task01.OldBooks
{
    internal class OldBooks
    {
        static void Main()
        {
            string serchedBook = Console.ReadLine();

            int bookChenkedCount = 0;

            string input;

            while ((input = Console.ReadLine()) != serchedBook)
            {
                if (input == "No More Books")
                {
                    break;
                }

                bookChenkedCount++;
            }

            if (input == serchedBook)
            {
                Console.WriteLine($"You checked {bookChenkedCount} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookChenkedCount} books.");
            }
        }
    }
}
