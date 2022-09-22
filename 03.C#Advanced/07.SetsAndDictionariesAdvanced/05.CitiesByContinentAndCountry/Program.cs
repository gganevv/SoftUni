using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string continent = inputArgs[0];
                string country = inputArgs[1];
                string city = inputArgs[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var contnent in continents)
            {
                Console.WriteLine($"{contnent.Key}:");
                foreach (var country in contnent.Value)
                {
                    Console.Write($"  {country.Key} -> ");
                    Console.WriteLine($"{string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
