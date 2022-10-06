using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int numberOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                int power = int.Parse(inputArgs[1]);
                int displacement = -1;
                string efficiency = null;

                if (inputArgs.Length > 2)
                {
                    if (char.IsDigit(inputArgs[2][0]))
                    {
                        displacement = int.Parse(inputArgs[2]);
                    }
                    else
                    {
                        efficiency = inputArgs[2];
                    }
                }
                if (inputArgs.Length > 3)
                {
                    efficiency = inputArgs[3];
                }
                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                string engineName = inputArgs[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineName);
                int weight = -1;
                string color = null;

                if (inputArgs.Length > 2)
                {
                    if (char.IsDigit(inputArgs[2][0]))
                    {
                        weight = int.Parse(inputArgs[2]);
                    }
                    else
                    {
                        color = inputArgs[2];
                    }
                }
                if (inputArgs.Length > 3)
                {
                    color = inputArgs[3];
                }
                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}