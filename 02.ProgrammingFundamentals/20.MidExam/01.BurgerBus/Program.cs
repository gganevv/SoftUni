using System;

namespace _01.BurgerBus
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());
            double totalProfit = 0;

            for (int city = 1; city <= numberOfCities; city++)
            {
                string cityName = Console.ReadLine();
                double income = double.Parse(Console.ReadLine());
                double expenses = double.Parse(Console.ReadLine());
                if (city % 3 == 0 && city % 5 != 0)
                {
                    expenses *= 1.5;
                }

                if (city % 5 == 0)
                {
                    income *= 0.9;
                }

                double profit = income - expenses;
                totalProfit += profit;

                Console.WriteLine($"In {cityName} Burger Bus earned {profit:f2} leva.");
            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
