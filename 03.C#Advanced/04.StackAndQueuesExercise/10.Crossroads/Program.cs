using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsQueue = new Queue<string>();
            int greenLightLength = int.Parse(Console.ReadLine());
            int freeWindowLength = int.Parse(Console.ReadLine());
            int carCounter = 0;
            
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    int currentGreenSeconds = greenLightLength;
                    while (currentGreenSeconds > 0 && carsQueue.Any())
                    {
                        string currentCar = carsQueue.Dequeue();
                        if (currentCar.Length <= currentGreenSeconds + freeWindowLength)
                        {
                            currentGreenSeconds -= currentCar.Length;
                            carCounter++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[currentGreenSeconds + freeWindowLength]}.");
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carCounter} total cars passed the crossroads.");
        }
    }
}
