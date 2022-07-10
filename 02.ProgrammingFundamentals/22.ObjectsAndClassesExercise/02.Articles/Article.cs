namespace _02.Articles
{
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

        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;
        public void Rename(string title) => Title = title;

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
