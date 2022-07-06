using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            string input = Console.ReadLine();
            int currentPosition = 0;

            while (input != "Love!")
            {
                string[] commandArgs = input.Split();
                int jump = int.Parse(commandArgs[1]);
                if (currentPosition + jump < houses.Count)
                {
                    currentPosition += jump;
                }
                else
                {
                    currentPosition = 0;
                }

                if (houses[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    houses[currentPosition] -= 2;
                    if (houses[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }

                input = Console.ReadLine();
            }

            bool allHasValentines = true;
            int notValentinesCount = 0;
            foreach (int house in houses)
            {
                if (house > 0)
                {
                    allHasValentines = false;
                    notValentinesCount++;
                }
            }
            Console.WriteLine($"Cupid's last position was {currentPosition}.");
            if (allHasValentines)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {notValentinesCount} places.");
            }
        }
    }
}
