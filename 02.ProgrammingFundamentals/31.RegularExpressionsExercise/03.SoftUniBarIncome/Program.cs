using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+(\.\d+)?)\$";
            double totalIncome = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                var order = Regex.Match(input, pattern);
                if (order.Success)
                {
                    string customerName = order.Groups["name"].Value;
                    string product = order.Groups["product"].Value;
                    int quantity = int.Parse(order.Groups["quantity"].Value);
                    double price = double.Parse(order.Groups["price"].Value);
                    double totalPrice = quantity * price;
                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
                    totalIncome += totalPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
