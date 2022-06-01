using System;

namespace _02.WeekendOrWorkingDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            string dayType;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    dayType = "Working day";
                    break;
                case "Saturday":
                case "Sunday":
                    dayType = "Weekend";
                    break;
                default:
                    dayType = "Error";
                    break;
            }
            Console.WriteLine(dayType);
        }
    }
}
