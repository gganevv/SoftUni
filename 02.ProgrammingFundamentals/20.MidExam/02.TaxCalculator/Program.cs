using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cars = Console.ReadLine().Split(">>").ToList();
            double totalTax = 0;

            for (int i = 0; i < cars.Count; i++)
            {
                string[] car = cars[i].Split();
                string carType = car[0];
                int carYears = int.Parse(car[1]);
                int kmsTravelled = int.Parse(car[2]);
                bool success = true;
                double tax = 0;
                switch (carType)
                {
                    case "family":
                        tax = kmsTravelled / 3000 * 12 + (50 - carYears * 5);
                        break;
                    case "heavyDuty":
                        tax = kmsTravelled / 9000 * 14 + (80 - carYears * 8);
                        break;
                    case "sports":
                        tax = kmsTravelled / 2000 * 18 + (100 - carYears * 9);
                        break;
                    default:
                        success = false;
                        Console.WriteLine("Invalid car type.");
                        break;
                }
                if (success)
                {
                    Console.WriteLine($"A {carType} car will pay {tax:f2} euros in taxes.");
                    totalTax += tax;
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {totalTax:f2} euros in taxes.");
        }
    }
}
