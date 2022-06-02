using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination;
            double moneySpent;
            string journeyType;
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    journeyType = "Camp";
                    moneySpent = budget * 0.3;
                }
                else
                {
                    journeyType = "Hotel";
                    moneySpent = budget * 0.7;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    journeyType = "Camp";
                    moneySpent = budget * 0.4;
                }
                else
                {
                    journeyType = "Hotel";
                    moneySpent = budget * 0.8;
                }
            }
            else
            {
                destination = "Europe";
                journeyType = "Hotel";
                moneySpent = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{journeyType} - {moneySpent:f2}");
        }
    }
}
