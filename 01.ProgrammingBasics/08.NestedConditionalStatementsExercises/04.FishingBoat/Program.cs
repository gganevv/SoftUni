using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double boatPrice = 0;
            switch (season)
            {
                case "Spring":
                    boatPrice = 3000;
                    break;
                case "Winter":
                    boatPrice = 2600;
                    break;
                default:
                    boatPrice = 4200;
                    break;
            }

            if (fishermans <= 6)
            {
                boatPrice *= 0.9;
            }
            else if (fishermans > 6 && fishermans <= 11)
            {
                boatPrice *= 0.85;
            }
            else if (fishermans > 11)
            {
                boatPrice *= 0.75;
            }

            if (fishermans % 2 == 0 && season != "Autumn")
            {
                boatPrice *= 0.95;
            }

            double diff = budget - boatPrice;
            if (diff >= 0)
            {
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(diff):f2} leva.");
            }
        }
    }
}
