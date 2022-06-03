using System;

namespace _01.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double ticketPrice;
            double transpotPrice;

            if (category == "VIP")
            {
                ticketPrice = 499.99;
            }
            else
            {
                ticketPrice = 249.99;
            }

            if (people < 5)
            {
                transpotPrice = budget * 0.75;
            }
            else if (people >= 5 && people < 10)
            {
                transpotPrice = budget * 0.6;
            }
            else if (people >= 10 && people < 25)
            {
                transpotPrice = budget * 0.5;
            }
            else if (people >= 25 && people < 50)
            {
                transpotPrice = budget * 0.4;
            }
            else
            {
                transpotPrice = budget * 0.25;
            }

            double totalPrice = transpotPrice + ticketPrice * people;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva.");
            }
        }
    }
}
