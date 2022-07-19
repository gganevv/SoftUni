using System.Collections.Generic;
using System.Text;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>");
            sb.AppendLine($"    {Title}");
            sb.AppendLine("</h1>");
            sb.AppendLine("<article>");
            sb.AppendLine($"    {Content}");
            sb.AppendLine("</article>");
            foreach (var comment in Comments)
            {
                sb.AppendLine("<div>");
                sb.AppendLine($"    {comment}");
                sb.AppendLine("</div>");
            }

            return sb.ToString().Trim();
        }
    }
}
