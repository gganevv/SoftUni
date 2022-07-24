using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emailPattern = @"(^|\s)[A-Za-z0-9][\w*\-\.]*[A-Za-z0-9]@[A-Za-z]+([.-][A-Za-z]+)+\b";
            string input = Console.ReadLine();
            var emails = Regex.Matches(input, emailPattern);
            foreach (Match match in emails)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
