using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main()
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int wagonMaxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();

                if (commandArgs.Length > 1)
                {
                    AddWagon(wagons, commandArgs);
                }
                else
                {
                    AddPassangers(wagons, command, wagonMaxCapacity);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void AddPassangers(List<int> wagons, string command, int wagonMaxCapacity)
        {
            int passangers = int.Parse(command);
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passangers <= wagonMaxCapacity)
                {
                    wagons[i] += passangers;
                    break;
                }
            }
        }

        private static void AddWagon(List<int> wagons, string[] commandArgs)
        {
            int wagon = int.Parse(commandArgs[1]);
            wagons.Add(wagon);
        }
    }
}
