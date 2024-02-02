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

            int output = RemoveBooks(db);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
               .Where(b => b.Copies < 4200)
               .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}


