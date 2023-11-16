using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.Articles
{
    internal class Articles
    {
        static void Main()
        {
            //Input
            string[] movies = Console.ReadLine().Split(", ");

            List<Article> articles = new List<Article>();

            string movieTitle = movies[0];
            string movieContent = movies[1];
            string movieAuthor = movies[2];

            Article article = new Article(movieTitle, movieContent, movieAuthor);
            articles.Add(article);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string comand = Console.ReadLine();

                string[] comandArgs = comand.Split(": ");

                if (comandArgs[0] == "Edit")
                {
                    string newContent = comandArgs[1];

                    article.Edit(newContent);
                }
                else if (comandArgs[0] == "ChangeAuthor")
                {
                    string newAuthor = comandArgs[1];

                    article.ChangeAuthor(newAuthor);
                }
                else if (comandArgs[0] == "Rename")
                {
                    string newTitle = comandArgs[1];

                    article.Rename(newTitle);
                }
            }

            foreach (Article item in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
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

            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }
        }
    }
}
