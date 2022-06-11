using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int student = 0;
            int standart = 0;
            int kid = 0;
            while (command != "Finish")
            {
                string movieName = command;
                int seats = int.Parse(Console.ReadLine());
                string ticketType = Console.ReadLine();
                double ticketsSold = 0;
                while (ticketType != "End")
                {
                    switch (ticketType)
                    {
                        case "student":
                            student++;
                            break;
                        case "standard":
                            standart++;
                            break;
                        default:
                            kid++;
                            break;
                    }
                    ticketsSold++;
                    if (ticketsSold == seats)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }
                Console.WriteLine($"{movieName} - {ticketsSold / seats * 100:f2}% full.");
                command = Console.ReadLine();
            }
            double totalTickets = student + standart + kid;
            Console.WriteLine("Total tickets: " + totalTickets);
            Console.WriteLine($"{student / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standart / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kid / totalTickets * 100:f2}% kids tickets.");
        }
    }
}