using System;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();

            string input = Console.ReadLine();

            while (input != "end")
            {
                input = VehicleParser(catalogue, input);
            }

            Console.WriteLine("Cars:");
            catalogue.Cars.OrderBy(x => x.Brand).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Trucks:");
            catalogue.Trucks.OrderBy(x => x.Brand).ToList().ForEach(x => Console.WriteLine(x));

        }

        private static string VehicleParser(Catalogue catalogue, string input)
        {
            string[] inputArgs = input.Split("/");
            string type = inputArgs[0];
            string brand = inputArgs[1];
            string model = inputArgs[2];
            int power = int.Parse(inputArgs[3]);
            if (type == "Car")
            {
                Car car = new Car(brand, model, power);
                catalogue.Cars.Add(car);
            }
            else
            {
                Truck truck = new Truck(brand, model, power);
                catalogue.Trucks.Add(truck);
            }

            input = Console.ReadLine();
            return input;
        }
    }
}
