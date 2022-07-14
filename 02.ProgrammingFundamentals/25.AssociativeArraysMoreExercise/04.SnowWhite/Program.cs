using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] inputArgs = input.Split(" <:> ");
                string dwarfName = inputArgs[0];
                string dwarfHatColor = inputArgs[1];
                int dwarfPhisics = int.Parse(inputArgs[2]);

                if (!dwarves.Any(x => x.Name == dwarfName && x.HatColor == dwarfHatColor))
                {
                    dwarves.Add(new Dwarf(dwarfName, dwarfHatColor, dwarfPhisics));
                }

                if (dwarves.First(x => x.Name == dwarfName && x.HatColor == dwarfHatColor).Phisics < dwarfPhisics)
                {
                    dwarves.First(x => x.Name == dwarfName && x.HatColor == dwarfHatColor).Phisics = dwarfPhisics;
                }

                input = Console.ReadLine();
            }

            dwarves = dwarves.OrderByDescending(x => x.Phisics).ThenByDescending(x => dwarves.Where(y => y.HatColor == x.HatColor).Count()).ToList();
            dwarves.ForEach(x => Console.WriteLine(x));
        }
    }
}
