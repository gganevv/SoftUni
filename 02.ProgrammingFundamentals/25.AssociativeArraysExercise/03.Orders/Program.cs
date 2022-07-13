using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                ParseProducts(products, input);
                input = Console.ReadLine();
            }

            products.ForEach(x => Console.WriteLine($"{x.Name} -> {x.TotalPrice:f2}"));
        }

        public static void ParseProducts(List<Product> products, string input)
        {
            string[] productArgs = input.Split(" ");
            string name = productArgs[0];
            double price = double.Parse(productArgs[1]);
            int quantity = int.Parse(productArgs[2]);
            if (!products.Any(x => x.Name == name))
            {
                products.Add(new Product(name, price, quantity));
            }
            else
            {
                Product product = products.Find(x => x.Name == name);
                product.Quantity += quantity;
                product.Price = price;
            }
        }
    }
}
