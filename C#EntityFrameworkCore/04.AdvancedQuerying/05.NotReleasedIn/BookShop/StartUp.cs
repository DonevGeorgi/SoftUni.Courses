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

            int input = int.Parse(Console.ReadLine());
            string output = GetBooksNotReleasedIn(db,input);

            Console.WriteLine(output);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title}");
            }

            return result.ToString().TrimEnd();
        }
    }
}


