namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string output = GetBooksByCategory(db, input);

            Console.WriteLine(output);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            List<string> filterCategorys =
                input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var books = context.BooksCategories
                .Select(b => new
                {
                    BookTitle = b.Book.Title,
                    BookCategoryName = b.Category.Name
                })
                .Where(b => filterCategorys.Contains(b.BookCategoryName.ToLower()))
                .OrderBy(x => x.BookTitle)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.BookTitle}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


