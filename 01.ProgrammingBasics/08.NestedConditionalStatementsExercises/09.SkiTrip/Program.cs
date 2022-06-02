using System;

namespace _09.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string review = Console.ReadLine();
            double price;

            if (roomType == "room for one person")
            {
                price = 18 * days;
            }
            else if (roomType == "apartment")
            {
                price = 25 * days;
                if (days < 10)
                {
                    price *= 0.7;
                }
                else if (days >= 10 && days <= 15)
                {
                    price *= 0.65;
                }
                else
                {
                    price *= 0.5;
                }
            }
            else
            {
                price = 35 * days;
                if (days < 10)
                {
                    price *= 0.9;
                }
                else if (days >= 10 && days <= 15)
                {
                    price *= 0.85;
                }
                else
                {
                    price *= 0.8;
                }
            }
            if (review == "positive")
            {
                price *= 1.25;
            }
            else
            {
                price *= 0.9;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
