using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<City> cities = new List<City>();

            while(input != "Sail")
            {
                string[] inputArgs = input.Split("||");
                string cityName = inputArgs[0];
                int cityPopulaton = int.Parse(inputArgs[1]);
                int cityGold = int.Parse(inputArgs[2]);

                if (!cities.Any(x => x.Name == cityName))
                {
                    cities.Add(new City(cityName));
                }
                cities.First(x => x.Name == cityName).Populaton += cityPopulaton;
                cities.First(x => x.Name == cityName).Gold += cityGold;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split("=>");
                string command = inputArgs[0];
                string townName = inputArgs[1];
                switch (command)
                {
                    case "Plunder":
                        Plunder(townName, int.Parse(inputArgs[2]), int.Parse(inputArgs[3]), cities);
                        break;
                    case "Prosper":
                        Prosper(townName, int.Parse(inputArgs[2]), cities);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                cities.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static void Plunder(string townName, int people, int gold, List<City> cities)
        {
            var currentCity = cities.First(x => x.Name == townName);
            currentCity.Populaton -= people;
            currentCity.Gold -= gold;
            if (currentCity.Populaton <= 0 || currentCity.Gold <= 0)
            {
                Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");
                Console.WriteLine($"{townName} has been wiped off the map!");
                cities.Remove(currentCity);
            }
            else
            {
                Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");
            }
        }

        private static void Prosper(string townName, int gold, List<City> cities)
        {
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                var currentCity = cities.First(x => x.Name == townName);
                currentCity.Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {currentCity.Gold} gold.");
            }
        }
    }

    class City
    {
        public City(string name)
        {
            Name = name;
            Populaton = 0;
            Gold = 0;
        }
        public string Name { get; set; }
        public int Populaton { get; set; }
        public int Gold { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Population: {Populaton} citizens, Gold: {Gold} kg";
        }
    }
}
