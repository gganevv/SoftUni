using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }
        public List<Fish> Fish { get; private set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if(Count == Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            Fish fishToRemove = Fish.FirstOrDefault(x => x.Weight == weight);
            if (fishToRemove == default)
            {
                return false;
            }

            Fish.Remove(fishToRemove);
            return true;
        }

        public Fish GetFish(string fishType) => Fish.FirstOrDefault(x => x.FishType == fishType);
        public Fish GetBiggestFish() => Fish.FirstOrDefault(x => x.Length == Fish.Max(x => x.Length));

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}