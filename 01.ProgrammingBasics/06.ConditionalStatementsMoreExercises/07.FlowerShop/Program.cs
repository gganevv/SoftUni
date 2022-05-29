using System;

namespace _07.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double magnoliaPrice = 3.25;
            double hyacinthPrice = 4;
            double rosePrice = 3.5;
            double cactusPrice = 8;

            int magnolias = int.Parse(Console.ReadLine());
            int hyacinths = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());
            double totalProfit = magnolias * magnoliaPrice + hyacinths * hyacinthPrice + roses * rosePrice + cactus * cactusPrice;
            double profitAfterTax = totalProfit * 0.95;
            double diff = profitAfterTax - giftPrice;
            if (profitAfterTax >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(diff)} leva.");
            }
            else
            {
                diff = Math.Abs(diff);
                Console.WriteLine($"She will have to borrow {Math.Ceiling(diff)} leva.");
            }
        }
    }
}
