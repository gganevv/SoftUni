using System;

namespace _03.DestinationFilm
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double discount = 1;
            double pricePerDay;

            if (destination == "Dubai")
            {
                discount = 0.7;
                if (season == "Winter")
                {
                    pricePerDay = 45000;
                }
                else
                {
                    pricePerDay = 40000;
                }
            }
            else if (destination == "Sofia")
            {
                discount = 1.25;
                if (season == "Winter")
                {
                    pricePerDay = 17000;
                }
                else
                {
                    pricePerDay = 12500;
                }
            }
            else
            {
                if (season == "Winter")
                {
                    pricePerDay = 24000;
                }
                else
                {
                    pricePerDay = 20250;
                }
            }

            double totalPrice = pricePerDay * days * discount;
            double diff = Math.Abs(budget - totalPrice);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {diff:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {diff:f2} leva more!");
            }
        }
    }
}
