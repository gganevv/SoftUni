using System;

namespace _05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = season == "Summer" ? "Alaska" : "Morocco";
            string accomodation = "";
            double price = 0;

            if (budget <= 1000)
            {
                accomodation = "Camp";
                price = season == "Summer" ? budget * 0.65 : budget * 0.45;
            }
            else if (budget > 1000 && budget <= 3000)
            {
                accomodation = "Hut";
                price = season == "Summer" ? budget * 0.8 : budget * 0.6;
            }
            else
            {
                accomodation = "Hotel";
                price = budget * 0.9;
            }

            Console.WriteLine($"{location} - {accomodation} - {price:f2}");
        }
    }
}
