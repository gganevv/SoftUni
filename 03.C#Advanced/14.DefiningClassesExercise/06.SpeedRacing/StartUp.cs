using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string model = inputArgs[0];
                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelConsumption = double.Parse(inputArgs[2]);
                
                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                string model = inputArgs[1];
                int distance = int.Parse(inputArgs[2]);

                Car car = cars.FirstOrDefault(x => x.Model == model);
                car.Drive(distance);

                input = Console.ReadLine();
            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
