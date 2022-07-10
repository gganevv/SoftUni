using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();
                string type = inputArgs[0];
                string model = inputArgs[1];
                string color = inputArgs[2];
                double horsePower = int.Parse(inputArgs[3]);
                vehicles.Add(new Vehicle(type, model, color, horsePower));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                Console.WriteLine(vehicles.First(x => x.Model == input));

                input = Console.ReadLine();
            }
            double carsAvg = 0;
            double trucksAvg = 0;
            if (vehicles.FindAll(x => x.Type == "car").Count > 0)
            {
                carsAvg = vehicles.Where(x => x.Type == "car").Average(x => x.HorsePower);
            }

            if (vehicles.FindAll(x => x.Type == "truck").Count > 0)
            {
                trucksAvg = vehicles.Where(x => x.Type == "truck").Average(x => x.HorsePower);
            }
           
            Console.WriteLine($"Cars have average horsepower of: {carsAvg:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvg:f2}.");
        }
    }
}
