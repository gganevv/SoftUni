using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warship = Console.ReadLine().Split(">").Select(int.Parse).ToList();

            int maxHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Retire")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Fire":
                        int index = int.Parse(commandArgs[1]);
                        int fireDemage = int.Parse(commandArgs[2]);
                        Fire(index, fireDemage, warship);
                        break;
                    case "Defend":
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);
                        int demage = int.Parse(commandArgs[3]);
                        Defend(startIndex, endIndex, demage, pirateShip);
                        break;
                    case "Repair":
                        int repairIndex = int.Parse(commandArgs[1]);
                        int health = int.Parse(commandArgs[2]);
                        Repair(repairIndex, health, maxHealth, pirateShip);
                        break;
                    case "Status":
                        Status(pirateShip, maxHealth);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }

        private static void Fire(int index, int fireDemage, List<int> warship)
        {
            if (index >= 0 && index < warship.Count)
            {
                warship[index] -= fireDemage;
                if (warship[index] <= 0)
                {
                    Console.WriteLine("You won! The enemy ship has sunken.");
                    Environment.Exit(0);
                }
            }

        }

        private static void Defend(int startIndex, int endIndex, int demage, List<int> pirateShip)
        {
            if (startIndex >= 0 && startIndex < pirateShip.Count && endIndex > startIndex && endIndex < pirateShip.Count)
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    pirateShip[i] -= demage;
                    if (pirateShip[i] <= 0)
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void Repair(int repairIndex, int health, int maxHealth, List<int> pirateShip)
        {
            if (repairIndex >= 0 && repairIndex < pirateShip.Count)
            {
                if (health + pirateShip[repairIndex] > maxHealth)
                {
                    pirateShip[repairIndex] = maxHealth;
                }
                else
                {
                    pirateShip[repairIndex] += health;
                }
            }
        }

        private static void Status(List<int> pirateShip, int maxHealth)
        {
            double minimumHealth = maxHealth / 5.0;
            int badSectors = 0;
            foreach (var sector in pirateShip)
            {
                if (sector < minimumHealth)
                {
                    badSectors++;
                }
            }

            Console.WriteLine($"{badSectors} sections need repair.");
        }
    }
}
