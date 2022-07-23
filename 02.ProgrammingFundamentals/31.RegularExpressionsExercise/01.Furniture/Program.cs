using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";
            List<string> products = new List<string>();
            double totalPrice = 0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    double currentPrice = double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                    products.Add(match.Groups["name"].Value);
                    totalPrice += currentPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            products.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
