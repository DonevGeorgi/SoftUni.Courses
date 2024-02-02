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
            string output = GetAuthorNamesEndingIn(db, input);

            Console.WriteLine(output);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    AuthorFirstName = a.FirstName,
                    AuthorFullName = a.FirstName + " " + a.LastName
                })
                .Where(a => a.AuthorFirstName.EndsWith(input))
                .OrderBy(x => x.AuthorFullName)
                .ToList();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.AuthorFullName}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


