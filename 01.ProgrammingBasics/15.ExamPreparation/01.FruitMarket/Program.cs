using System;

namespace _01.FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasKgs = double.Parse(Console.ReadLine());
            double orangeKgs = double.Parse(Console.ReadLine());
            double raspberriesKgs = double.Parse(Console.ReadLine());
            double strawberriesKgs = double.Parse(Console.ReadLine());

            double raspberriesPrice = strawberriesPrice * 0.5;
            double orangePrice = raspberriesPrice * 0.6;
            double bananaPrice = raspberriesPrice * 0.2;

            double total = strawberriesPrice * strawberriesKgs + bananaPrice * bananasKgs + orangeKgs * orangePrice + raspberriesKgs * raspberriesPrice;

            Console.WriteLine($"{total:f2}");
        }
    }
}
