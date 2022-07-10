using System;
using System.Collections.Generic;

namespace _03.Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articleArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = articleArgs[0];
                string content = articleArgs[1];
                string author = articleArgs[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }
            Console.ReadLine();
            articles.ForEach(x => Console.WriteLine(x));
        }
    }
}
