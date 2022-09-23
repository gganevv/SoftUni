using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandArgs = input.Split(", ");
                string command = commandArgs[0];
                string plate = commandArgs[1];

                if (command == "IN")
                {
                    parking.Add(plate);
                }
                else
                {
                    parking.Remove(plate);
                }

                input = Console.ReadLine();
            }

            if (parking.Count > 0)
            {
                foreach (var plate in parking)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
