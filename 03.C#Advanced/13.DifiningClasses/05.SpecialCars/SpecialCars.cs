using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tiresCollection = new List<Tire[]>();
            List<Engine> engineCollection = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                AddTires(tiresCollection, input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "Engines done")
            {
                AddEngines(engineCollection, input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "Show special")
            {
                AddCars(tiresCollection, engineCollection, cars, input);
                input = Console.ReadLine();
            }

            List<Car> filteredCars = FilterCars(cars);
            foreach (var car in filteredCars)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }
        }

        private static List<Car> FilterCars(List<Car> cars)
        {
            List<Car> filteredCars = new List<Car>();
            foreach (var car in cars)
            {
                double pressureSum = 0;
                foreach (var tire in car.Tires)
                {
                    pressureSum += tire.Pressure;
                }
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && pressureSum >= 9 && pressureSum <= 10)
                {
                    filteredCars.Add(car);
                }
            }

            return filteredCars;
        }

        private static void AddCars(List<Tire[]> tiresCollection, List<Engine> engineCollection, List<Car> cars, string input)
        {
            string[] inputArgs = input.Split();
            string make = inputArgs[0];
            string model = inputArgs[1];
            int year = int.Parse(inputArgs[2]);
            double fuelQuantity = double.Parse(inputArgs[3]);
            double fuelConsumption = double.Parse(inputArgs[4]);
            int engineIndex = int.Parse(inputArgs[5]);
            int tiresIndex = int.Parse(inputArgs[6]);

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineCollection.ElementAt(engineIndex), tiresCollection.ElementAt(tiresIndex));
            cars.Add(car);
        }

        private static void AddEngines(List<Engine> engineCollection, string input)
        {
            double[] engineArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            Engine engine = new Engine((int)engineArr[0], engineArr[1]);

            engineCollection.Add(engine);
        }

        private static void AddTires(List<Tire[]> tiresCollection, string input)
        {
            double[] tireArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            Tire tire1 = new Tire((int)tireArr[0], tireArr[1]);
            Tire tire2 = new Tire((int)tireArr[2], tireArr[3]);
            Tire tire3 = new Tire((int)tireArr[4], tireArr[5]);
            Tire tire4 = new Tire((int)tireArr[6], tireArr[7]);

            Tire[] tires = new Tire[4];
            tires[0] = tire1;
            tires[1] = tire2;
            tires[2] = tire3;
            tires[3] = tire4;

            tiresCollection.Add(tires);
        }
    }
}