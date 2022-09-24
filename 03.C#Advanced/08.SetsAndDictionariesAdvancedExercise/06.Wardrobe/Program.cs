using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ");
                string color = inputArgs[0];
                string[] clothes = inputArgs[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentCloth = clothes[j];
                    if (!wardrobe[color].ContainsKey(currentCloth))
                    {
                        wardrobe[color].Add(currentCloth, 0);
                    }

                    wardrobe[color][currentCloth]++;
                }
            }

            string[] desiredCloth = Console.ReadLine().Split(" ");

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    string clothOutput = $"* {cloth.Key} - {cloth.Value}";
                    if (desiredCloth[0] == color.Key && desiredCloth[1] == cloth.Key)
                    {
                        clothOutput += " (found!)";
                    }
                    Console.WriteLine(clothOutput);
                }
            }
        }
    }
}
