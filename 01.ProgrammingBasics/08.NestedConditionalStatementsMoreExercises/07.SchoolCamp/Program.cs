using System;

namespace _07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentsNumber = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            string sport = "";
            double price = 0;

            if (season == "Winter")
            {
                if (groupType == "girls")
                {
                    sport = "Gymnastics";
                    price = 9.6 * studentsNumber * days;
                }
                else if (groupType == "boys")
                {
                    sport = "Judo";
                    price = 9.6 * studentsNumber * days;
                }
                else
                {
                    sport = "Ski";
                    price = 10 * studentsNumber * days;
                }
            }
            else if (season == "Spring")
            {
                if (groupType == "girls")
                {
                    sport = "Athletics";
                    price = 7.2 * studentsNumber * days;
                }
                else if (groupType == "boys")
                {
                    sport = "Tennis";
                    price = 7.2 * studentsNumber * days;
                }
                else
                {
                    sport = "Cycling";
                    price = 9.5 * studentsNumber * days;
                }
            }
            else
            {
                if (groupType == "girls")
                {
                    sport = "Volleyball";
                    price = 15 * studentsNumber * days;
                }
                else if (groupType == "boys")
                {
                    sport = "Football";
                    price = 15 * studentsNumber * days;
                }
                else
                {
                    sport = "Swimming";
                    price = 20 * studentsNumber * days;
                }
            }
            if (studentsNumber >= 50)
            {
                price *= 0.5;
            }
            else if (studentsNumber < 50 && studentsNumber >= 20)
            {
                price *= 0.85;
            }
            else if (studentsNumber < 20 && studentsNumber >= 10)
            {
                price *= 0.95;
            }

            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}
