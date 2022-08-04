using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split("<->");
                string name = inputArgs[0];
                int rarity = int.Parse(inputArgs[1]);
                Plant plant = new Plant(name, rarity);
                if (!plants.Any(x => x.Name == name))
                {
                    plants.Add(plant);
                }
                else
                {
                    plants.First(x => x.Name == name).Rarity = rarity;
                }
            }

            string input = Console.ReadLine();
            while (input != "Exhibition")
            {
                string[] inputArgs = input.Split(" ");
                string command = inputArgs[0];
                string name = inputArgs[1];

                switch (command)
                {
                    case "Rate:":
                        RatePlant(name, int.Parse(inputArgs[3]), plants);
                        break;
                    case "Update:":
                        UpdatePlant(name, int.Parse(inputArgs[3]), plants);
                        break;
                    case "Reset:":
                        ResetPlant(name, plants);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            plants.ForEach(Console.WriteLine);
        }

        private static void RatePlant(string name, int rating, List<Plant> plants)
        {
            Plant plant = ValidatePlant(name, plants);
            if (plant != null)
            {
                plant.Ratings.Add(rating);
            }
        }

        private static void UpdatePlant(string name, int rarity, List<Plant> plants)
        {
            Plant plant = ValidatePlant(name, plants);
            if (plant != null)
            {
                plant.Rarity = rarity;
            }
        }

        private static void ResetPlant(string name, List<Plant> plants)
        {
            Plant plant = ValidatePlant(name, plants);
            if (plant != null)
            {
                plant.Ratings.Clear();
            }
        }

        private static Plant ValidatePlant(string name, List<Plant> plants)
        {
            if (plants.Any(x => x.Name == name))
            {
                return plants.First(x => x.Name == name);
            }
            else
            {
                Console.WriteLine("error");
                return null;
            }
        }
    }
}
