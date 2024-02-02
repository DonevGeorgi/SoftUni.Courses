namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string output = GetGoldenBooks(db);

            Console.WriteLine(output);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .ToList()
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Copies,
                    EditionType = b.EditionType.ToString()
                })
                .Where(b => b.Copies < 5000 && b.EditionType == "Gold")
                .OrderBy(b => b.BookId);

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


