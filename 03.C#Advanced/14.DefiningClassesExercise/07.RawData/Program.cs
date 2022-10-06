using System;
using System.Collections.Generic;

namespace _07.RawData
{
    public class Program
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = inputArgs[0];
                int engineSpeed = int.Parse(inputArgs[1]);
                int enginePower = int.Parse(inputArgs[2]);
                int cargoWeight = int.Parse(inputArgs[3]);
                string cargoType = inputArgs[4];
                double tire1Pressure = double.Parse(inputArgs[5]);
                int tire1Age = int.Parse(inputArgs[6]);
                double tire2Pressure = double.Parse(inputArgs[7]);
                int tire2Age = int.Parse(inputArgs[8]);
                double tire3Pressure = double.Parse(inputArgs[9]);
                int tire3Age = int.Parse(inputArgs[10]);
                double tire4Pressure = double.Parse(inputArgs[11]);
                int tire4Age = int.Parse(inputArgs[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);
                List<Tire> tires = new List<Tire> { tire1, tire2, tire3, tire4 };

                Car car = new Car(carModel, engine, cargo, tires);
                cars.Add(car);
            }

            string filter = Console.ReadLine();
            if (filter == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "fragile")
                    {
                        foreach (var tire in car.Tires)
                        {
                            if (tire.Pressure < 1)
                            {
                                Console.WriteLine(car.Model);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }


        }
    }
}
