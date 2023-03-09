namespace BookShop;

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
        Console.WriteLine(GetBooksByPrice(db));
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
}