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
            string output = GetBookTitlesContaining(db,input);

            Console.WriteLine(output);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Select(b => new
                {
                    BookTitle = b.Title
                })
                .Where(b => b.BookTitle.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.BookTitle)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.BookTitle}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


