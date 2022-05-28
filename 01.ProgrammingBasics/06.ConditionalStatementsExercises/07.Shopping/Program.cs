using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCardsNumber = int.Parse(Console.ReadLine());
            int processorsNumber = int.Parse(Console.ReadLine());
            int ramNumber = int.Parse(Console.ReadLine());

            double videoCardsPrice = videoCardsNumber * 250;
            double processorsPrice = videoCardsPrice * 0.35 * processorsNumber;
            double ramsPrice = videoCardsPrice * 0.1 * ramNumber;

            double totalPirce = videoCardsPrice + processorsPrice + ramsPrice;
            if (videoCardsNumber > processorsNumber)
            {
                totalPirce *= 0.85;
            }

            double diff = budget - totalPirce;
            if (diff >= 0)
            {
                Console.WriteLine($"You have {diff:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(diff):f2} leva more!");
            }
        }
    }
}
