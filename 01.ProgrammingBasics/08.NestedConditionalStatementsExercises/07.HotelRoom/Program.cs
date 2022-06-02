using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartmentPrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50 * days;
                apartmentPrice = 65 * days;
                if (days > 7 && days < 15)
                {
                    studioPrice *= 0.95;
                }
                else if (days > 14)
                {
                    studioPrice *= 0.7;
                }

            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.2 * days;
                apartmentPrice = 68.7 * days;
                if (days > 14)
                {
                    studioPrice *= 0.8;
                }
            }
            else if(month == "July" || month == "August")
            {
                studioPrice = 76 * days;
                apartmentPrice = 77 * days;
            }
            if (days > 14)
            {
                apartmentPrice *= 0.9;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
