using System;
using System.Collections.Generic;

namespace _05.HTML
{
    public class Article
    {
        public Article(string title, string content)
        {
            Title = title;
            Content = content;
            Comments = new List<string>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Comments { get; set; }

        public void ToHTML()
        {
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {Title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"   {Content}");
            Console.WriteLine("</article>");
            for (int i = 0; i < Comments.Count; i++)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {Comments[i]}");
                Console.WriteLine("</div>");
            }
        }
    }
}
