using System;

namespace _05.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double filmPrice = budget * 0.1;
            if (statists > 150)
            {
                filmPrice += statists * clothingPrice * 0.9;
            }
            else
            {
                filmPrice += statists * clothingPrice;
            }

            double diff = budget - filmPrice;

            if (diff >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(diff):f2} leva more.");
            }
        }
    }
}
