using System;
using System.Collections.Generic;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            string cargo = Console.ReadLine();
            if (cargo == "fragile")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.Type == cargo && car.Cargo.Weight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.Type == cargo && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
