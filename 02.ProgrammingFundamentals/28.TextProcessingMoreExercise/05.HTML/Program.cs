using System;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            
            Article article = new Article(title, content);
            
            string comment = Console.ReadLine();
            while (comment != "end of comments")
            {
                article.Comments.Add(comment);
                comment = Console.ReadLine();
            }

            Console.WriteLine(article);
        }
    }
}
