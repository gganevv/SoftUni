using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList());

            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            while (water.Any() && flour.Any())
            {
                double currentWarer = water.Dequeue();
                double currentFlour = flour.Pop();

                double ratio = currentWarer * 100 / (currentWarer + currentFlour);
                switch (ratio)
                {
                    case 50:
                        products["Croissant"]++;
                        break;
                    case 40:
                        products["Muffin"]++;
                        break;
                    case 30:
                        products["Baguette"]++;
                        break;
                    case 20:
                        products["Bagel"]++;
                        break;
                    default:
                        products["Croissant"]++;
                        flour.Push(Math.Abs(currentFlour - currentWarer));
                        break;
                }

            }

            products = products.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            string waterLeft = "Water left: ";
            waterLeft += water.Any() ? $"{String.Join(", ", water)}" : "None";
            string flourLeft = "Flour left: ";
            flourLeft += flour.Any() ? $"{String.Join(", ", flour)}" : "None";
            Console.WriteLine(waterLeft);
            Console.WriteLine(flourLeft);
        }
    }
}
