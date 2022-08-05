using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    internal class Program
    {
        const int MAX_FUEL = 75;
        const int MIN_MILEAGE = 10_000;
        const int MAX_MILEAGE = 100_000;
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string currentCar = Console.ReadLine();
                string[] currentCarArgs = currentCar.Split("|");
                string name = currentCarArgs[0];
                int mileage = int.Parse(currentCarArgs[1]);
                int fuel = int.Parse(currentCarArgs[2]);

                Car car = new Car(name, mileage, fuel);
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] inputArgs = input.Split(" : ");
                string command = inputArgs[0];
                string carName = inputArgs[1];
                switch (command)
                {
                    case "Drive":
                        DriveCar(carName, int.Parse(inputArgs[2]), int.Parse(inputArgs[3]), cars);
                        break;
                    case "Refuel":
                        RefuelCar(carName, int.Parse(inputArgs[2]), cars);
                        break;
                    case "Revert":
                        RevertCar(carName, int.Parse(inputArgs[2]), cars);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            cars.ForEach(x => Console.WriteLine(x));
        }

        private static void DriveCar(string carName, int distance, int fuel, List<Car> cars)
        {
            var currentCar = cars.First(x => x.Name == carName);
            if (currentCar.Fuel >= fuel)
            {
                currentCar.Mileage += distance;
                currentCar.Fuel -= fuel;
                Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }

            if (currentCar.Mileage > MAX_MILEAGE)
            {
                cars.Remove(currentCar);
                Console.WriteLine($"Time to sell the {carName}!");
            }
        }

        private static void RefuelCar(string carName, int fuel, List<Car> cars)
        {
            var currentCar = cars.First(x => x.Name == carName);
            int startingFuel = currentCar.Fuel;
            currentCar.Fuel += fuel;
            if (currentCar.Fuel > MAX_FUEL)
            {
                currentCar.Fuel = MAX_FUEL;
            }
            Console.WriteLine($"{carName} refueled with {currentCar.Fuel - startingFuel} liters");
        }

        private static void RevertCar(string carName, int kms, List<Car> cars)
        {
            var currentCar = cars.First(x => x.Name == carName);
            int startingMileage = currentCar.Mileage;
            currentCar.Mileage -= kms;
            if (currentCar.Mileage < MIN_MILEAGE)
            {
                currentCar.Mileage = MIN_MILEAGE;
            }
            else
            {
                Console.WriteLine($"{carName} mileage decreased by {startingMileage - currentCar.Mileage} kilometers");
            }
        }
    }

    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}
