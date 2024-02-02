namespace BookShop
{
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string output = GetBooksByAgeRestriction(db, input);

            Console.WriteLine(output);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    AgeRestriction = b.AgeRestriction.ToString().ToLower()
                })
                .ToList()
                .Where(b => b.AgeRestriction == command.ToLower())
                .OrderBy(t => t.Title);

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


