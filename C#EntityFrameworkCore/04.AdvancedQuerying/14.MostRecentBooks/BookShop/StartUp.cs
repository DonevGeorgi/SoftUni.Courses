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

            string output = GetMostRecentBooks(db);
            Console.WriteLine(output);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategotyName = c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        BookReleaseYear = b.Book.ReleaseDate!.Value.Year
                    })
                    .Take(3)
                    .ToList()
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.CategotyName}");

                if (category.Books.Count > 0)
                {
                    foreach (var book in category.Books)
                    {
                        result.AppendLine($"{book.BookTitle} ({book.BookReleaseYear})");
                    }
                }
            }

            return result.ToString().Trim();
        }
    }
}


