using System;

namespace _02.FamilyVacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());
            double increasePercent = int.Parse(Console.ReadLine());

            if (nights > 7)
            {
                nightPrice *= 0.95;
            }

            double neededMoney = nights * nightPrice + (budget * increasePercent / 100);
            double diff = Math.Abs(budget - neededMoney);

            if (budget >= neededMoney)
            {
                Console.WriteLine($"Ivanovi will be left with {diff:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{diff:f2} leva needed.");
            }
            
        }
    }
}
