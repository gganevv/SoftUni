using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WildZoo
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = 100f == 100d;
            Console.WriteLine(isTrue);
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            Dictionary<string, int> areas = new Dictionary<string, int>();

            while (input != "EndDay")
            {
                string[] commandArgs = input.Split(' ');
                if (commandArgs[0] == "Add:")
                {
                    string[] inputArgs = commandArgs[1].Split('-');
                    string name = inputArgs[0];
                    int neededFood = int.Parse(inputArgs[1]);
                    string area = inputArgs[2];

                    if (!animals.Any(x => x.Name == name))
                    {
                        animals.Add(new Animal(name, neededFood, area));
                        if (!areas.ContainsKey(area))
                        {
                            areas.Add(area, 0);
                        }
                        areas[area]++;
                    }
                    else
                    {
                        animals.First(x => x.Name == name).NeededFood += neededFood;
                    }

                }
                else if (commandArgs[0] == "Feed:")
                {
                    string[] inputArgs = commandArgs[1].Split('-');
                    string name = inputArgs[0];
                    int food = int.Parse(inputArgs[1]);

                    if (animals.Any(x => x.Name == name))
                    {
                        Animal animal = animals.First(x => x.Name == name);
                        animal.NeededFood -= food;
                        if (animal.NeededFood <= 0)
                        {
                            animals.Remove(animal);
                            Console.WriteLine($"{name} was successfully fed");
                            areas[animal.Area]--;
                            if (areas[animal.Area] == 0)
                            {
                                areas.Remove(animal.Area);
                            }
                        }
                    }
                }



                input = Console.ReadLine();
            }

            Console.WriteLine("Animals:");
            animals.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Areas with hungry animals:");
            foreach (var area in areas)
            {
                Console.WriteLine($"{area.Key}: {area.Value}");
            }

        }
    }

    class Animal
    {
        public Animal(string name, int neededFood, string area)
        {
            Name = name;
            NeededFood = neededFood;
            Area = area;
        }
        public string Name { get; set; }
        public int NeededFood { get; set; }
        public string Area { get; set; }

        public override string ToString()
        {
            return $" {Name} -> {NeededFood}g";
        }
    }
}