namespace BookShop;

using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        //02. Books by Age Restriction
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByAgeRestriction(db, input));

        //03. Golden Books
        //Console.WriteLine(GetGoldenBooks(db));

        //04. Books by Price
        //Console.WriteLine(GetBooksByPrice(db));

        //05. Not released In
        //int year = int.Parse(Console.ReadLine());
        //Console.WriteLine(GetBooksNotReleasedIn(db, year));

        //06. Book Titles by Category
        //string categories = Console.ReadLine();
        //Console.WriteLine(GetBooksByCategory(db, categories));

        //07. Released Before Date
        //string date = Console.ReadLine();
        //Console.WriteLine(GetBooksReleasedBefore(db, date));

        //08. Author Search
        //string input = Console.ReadLine();
        //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

        //09. Book Search
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBookTitlesContaining(db, input));

        //10. Book Search by Author
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByAuthor(db, input));

        //11. Count Books
        //int length = int.Parse(Console.ReadLine());
        //Console.WriteLine(CountBooks(db, length));

        //12. Total Book Copies
        //Console.WriteLine(CountCopiesByAuthor(db));

        //13. Profit by Category
        Console.WriteLine(GetTotalProfitByCategory(db));
    }

    //02. Books by Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string ageRestriction)
    {
        StringBuilder sb = new StringBuilder();
        List<string> bookTitles = new List<string>();

        if(Enum.TryParse(ageRestriction, true, out AgeRestriction ageR))
        {
            bookTitles = context.Books
            .Where(b => b.AgeRestriction == ageR)
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();
        }

        foreach (var book in bookTitles)
        {
            sb.AppendLine(book);
        }
        return sb.ToString().TrimEnd();
    }

    //03. Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {

        var books = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();

        return (string.Join(Environment.NewLine, books));
    }

    //04. Books by Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                b.Title,
                b.Price
            });

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //05. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title);


        return string.Join(Environment.NewLine, books);
    }

    //06. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();
        string[] catogories = input.ToLower().Split();

        var bookCategories = context
            .BooksCategories
            .Where(bc => catogories.Contains(bc.Category.Name.ToLower()))
            .Select(b => b.Book.Title)
            .OrderBy(bc => bc)
            .ToArray();

        foreach (var book in bookCategories)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }

    //07. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);
        StringBuilder sb = new StringBuilder();

        var books = context.Books
            .Where(b => b.ReleaseDate < releaseDate)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                EditionType = b.EditionType.ToString(),
                b.Price,
            })
            .ToArray();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //08. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => a.FirstName + " " + a.LastName)
            .OrderBy(a => a)
            .ToList();

        return string.Join(Environment.NewLine, authors);
    }

    //09. Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var books = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();
            
            return string.Join(Environment.NewLine, books);
    }

    //10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();
        
        var books = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .Select(b => new
            {
                b.Title,
                Author = b.Author.FirstName + " " + b.Author.LastName,
                b.BookId
            })
            .OrderBy(b => b.BookId)
            .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} ({book.Author})");
        }

        return sb.ToString().TrimEnd();
    }

    //11. Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int numberOfBooks = context.Books
            .Where(b => b.Title.Length > lengthCheck)
            .Count();

        return numberOfBooks;
    }

    //12. Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var authors = context.Authors
            .Include(a => a.Books)
            .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName,
                TotalCopies = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(a => a.TotalCopies);

        foreach (var author in authors)
        {
            sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
        }

        return sb.ToString().TrimEnd();
    }

    //13. Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var categories = context.Categories
            .Select(c => new
            {
                c.Name,
                TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
            })
            .OrderByDescending(c => c.TotalProfit);

        foreach (var category in categories)
        {
            sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
        }

        return sb.ToString().TrimEnd();
    }
}