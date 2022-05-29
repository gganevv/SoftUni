using System;

namespace _08.FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelInTank = double.Parse(Console.ReadLine());
            switch (fuelType)
            {
                case "Diesel":
                case "Gasoline":
                case "Gas":
                    if (fuelInTank >= 25)
                    {
                        Console.WriteLine($"You have enough {fuelType.ToLower()}.");
                    }
                    else
                    {
                        Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid fuel!");
                    break;
            }
        }
    }
}
