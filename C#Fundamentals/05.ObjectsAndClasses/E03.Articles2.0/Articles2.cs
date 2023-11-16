using System;
using System.Collections.Generic;

namespace E03.Articles2._0
{
    internal class Articles2
    {
        static void Main()
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            string input = string.Empty;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();

                string[] inputArgs = input.Split(", ");

                string newTitle = inputArgs[0];
                string newContent = inputArgs[1];
                string newAuthor = inputArgs[2];

                Article article = new Article(newTitle, newContent, newAuthor);
                articles.Add(article);
            }

            //Output
            foreach (Article item in articles)
            {
                Console.WriteLine(item);
            }
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
