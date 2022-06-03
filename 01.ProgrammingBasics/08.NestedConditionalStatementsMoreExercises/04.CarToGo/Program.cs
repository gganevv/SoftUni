using System;

namespace _04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string carClass = "";
            string carType = "";
            double price = 0;

            if (budget <= 100)
            {
                carClass = "Economy class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    price = budget * 0.35;
                }
                else
                {
                    carType = "Jeep";
                    price = budget * 0.65;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                carClass = "Compact class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    price = budget * 0.45;
                }
                else
                {
                    carType = "Jeep";
                    price = budget * 0.8;
                }
            }
            else if (budget > 500)
            {
                carClass = "Luxury class";
                carType = "Jeep";
                price = budget * 0.9;
            }

            Console.WriteLine(carClass);
            Console.WriteLine($"{carType} - {price:f2}");
        }
    }
}
