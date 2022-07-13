using System;
using System.Collections.Generic;

namespace _04.SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string command = inputArgs[0];
                string userName = inputArgs[1];

                if (command == "register")
                {
                    string plateNumber = inputArgs[2];

                    if (parking.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                    }
                    else
                    {
                        parking.Add(userName, plateNumber);
                        Console.WriteLine($"{userName} registered {plateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (!parking.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        parking.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }

            foreach (var plate in parking)
            {
                Console.WriteLine($"{plate.Key} => {plate.Value}");
            }
        }
    }
}
