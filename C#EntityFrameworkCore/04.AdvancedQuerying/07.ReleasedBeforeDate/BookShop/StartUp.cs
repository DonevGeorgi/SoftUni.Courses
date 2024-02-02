namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string output = GetBooksReleasedBefore(db, input);

            Console.WriteLine(output);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new StringBuilder();

            var dateFilter = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price,
                    BookEditionType = b.EditionType,
                    BookReleaseDate = b.ReleaseDate.Value
                })
                .Where(b => b.BookReleaseDate < dateFilter)
                .OrderByDescending(x => x.BookReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.BookTitle} - {book.BookEditionType} - ${book.BookPrice:f2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


