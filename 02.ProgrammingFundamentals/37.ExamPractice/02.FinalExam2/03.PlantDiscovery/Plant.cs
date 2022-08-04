using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<double>();
        }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Ratings;

        public override string ToString()
        {
            if (Ratings.Count > 0)
            {
                return $"- {Name}; Rarity: {Rarity}; Rating: {Ratings.Average():f2}";
            }
            else
            {
                return $"- {Name}; Rarity: {Rarity}; Rating: {0:f2}";
            }
        }
    }
}
