using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalCalories = 0;
            string input = Console.ReadLine();
            string productPattern = @"([#|])(?<productName>[A-Za-z ]+)\1(?<day>\d{2})\/(?<month>\d{2})\/(?<year>\d{2})\1(?<calories>\d{1,4})\1";
            var products = Regex.Matches(input, productPattern);

            foreach (Match product in products)
            {
                totalCalories += int.Parse(product.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            
            foreach (Match product in products)
            {
                Console.WriteLine($"Item: {product.Groups["productName"].Value}, Best before: {product.Groups["day"].Value}/{product.Groups["month"].Value}/{product.Groups["year"].Value}, Nutrition: {product.Groups["calories"].Value}");
            }

        }
    }
}
