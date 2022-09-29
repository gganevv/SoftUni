using System;
using System.Linq;

public class CountUppercaseWords
{
    static Func<string, bool> isFirstLetterUppercase =
        x => x[0] == x.ToUpper()[0];
    static void Main()
    {
        Console.WriteLine(
            String.Join("\r\n",
            Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).
            Where(isFirstLetterUppercase)));
    }
}