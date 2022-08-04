using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            List<string> destinations = new List<string>();
            int travelPoints = 0;

            var matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                destinations.Add(match.Groups["destination"].Value);
                travelPoints += match.Groups["destination"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
