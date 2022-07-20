using System;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string comment = Console.ReadLine();

            Article article = new Article(title, content);

            while (comment != "end of comments")
            {
                article.Comments.Add(comment);

                comment = Console.ReadLine();
            }

            article.ToHTML();
        }
    }
}
