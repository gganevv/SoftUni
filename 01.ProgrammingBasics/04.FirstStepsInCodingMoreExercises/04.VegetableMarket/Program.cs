using System;

namespace _04.VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPricePerKg = double.Parse(Console.ReadLine());
            double fruitsPricePerKg = double.Parse(Console.ReadLine());
            int vegetablesKgs = int.Parse(Console.ReadLine());
            int fruitsKgs = int.Parse(Console.ReadLine());
            double vegetablesPrice = vegetablesPricePerKg * vegetablesKgs;
            double fruitsPrice = fruitsPricePerKg * fruitsKgs;
            double totalPrice = vegetablesPrice + fruitsPrice;
            double totalPriceEur = totalPrice / 1.94;
            Console.WriteLine($"{totalPriceEur:f2}");

        }
    }
}
