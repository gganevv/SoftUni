using System;

namespace _03.SantasHoliday
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string review = Console.ReadLine();

            double roomPrice = 0;

            if (roomType == "room for one person")
            {
                roomPrice = 18 * (days - 1);
            }
            else if (roomType == "apartment")
            {
                roomPrice = 25 * (days - 1);
                if (days < 10)
                {
                    roomPrice *= 0.7;
                }
                else if (days >= 10 && days <= 15)
                {
                    roomPrice *= 0.65;
                }
                else
                {
                    roomPrice *= 0.5;
                }
            }
            else
            {
                roomPrice = 35 * (days - 1);
                if (days < 10)
                {
                    roomPrice *= 0.9;
                }
                else if (days >= 10 && days <= 15)
                {
                    roomPrice *= 0.85;
                }
                else
                {
                    roomPrice *= 0.8;
                }
            }
            if (review == "positive")
            {
                roomPrice *= 1.25;
            }
            else
            {
                roomPrice *= 0.9;
            }

            Console.WriteLine($"{roomPrice:f2}");
        }
    }
}
