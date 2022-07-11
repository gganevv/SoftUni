using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
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

                Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string carModel = commandArgs[1];
                int amount = int.Parse(commandArgs[2]);
                Car currentCar = cars.First(x => x.Model == carModel);
                currentCar.Drive(amount);

                command = Console.ReadLine();
            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
