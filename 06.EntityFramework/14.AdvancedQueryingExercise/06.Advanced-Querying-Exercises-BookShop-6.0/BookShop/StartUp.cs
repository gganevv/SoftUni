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

        //02. Age Restriction
        string input = Console.ReadLine();
        Console.WriteLine(GetBooksByAgeRestriction(db, input));

    }

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
}