using System;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Article article = new Article(articleArgs[0], articleArgs[1], articleArgs[2]);
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string change = commandArgs[1];
                switch (command)
                {
                    case "Edit":
                        article.Edit(change);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(change);
                        break;
                    case "Rename":
                        article.Rename(change);
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(article);
        }
    }
}
