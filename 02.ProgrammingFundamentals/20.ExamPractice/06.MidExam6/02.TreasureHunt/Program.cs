using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine().Split("|").ToList();

            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                string[] commandTokens = input.Split();
                string command = commandTokens[0];
                switch (command)
                {
                    case "Loot":
                        Loot(commandTokens, loot);
                        break;
                    case "Drop":
                        Drop(int.Parse(commandTokens[1]), loot);
                        break;
                    case "Steal":
                        Steal(int.Parse(commandTokens[1]), loot);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            CalculateTreasure(loot);
        }

        private static void Loot(string[] treasures, List<string> loot)
        {
            for (int i = 1; i < treasures.Length; i++)
            {
                string treasure = treasures[i];
                if (!loot.Contains(treasure))
                {
                    loot.Insert(0, treasure);
                }
            }
        }

        private static void Drop(int index, List<string> loot)
        {
            if (index >= 0 && index < loot.Count - 1)
            {
                string tempLoot = loot[index];
                loot.RemoveAt(index);
                loot.Add(tempLoot);
            }
        }

        private static void Steal(int count, List<string> loot)
        {
            List<string> stolenTreasures = new List<string>();
            for (int i = loot.Count - count; i < loot.Count; i++)
            {
                if (i < 0)
                {
                    i = 0;
                }
                stolenTreasures.Add(loot[i]);
                loot.RemoveAt(i);
                i--;
            }


            Console.WriteLine(string.Join(", ", stolenTreasures));
        }

        private static void CalculateTreasure(List<string> loot)
        {
            if (loot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double sum = 0;
                for (int i = 0; i < loot.Count; i++)
                {
                    sum += loot[i].Length;
                }

                sum /= loot.Count;
                Console.WriteLine($"Average treasure gain: {sum:f2} pirate credits.");
            }
        }
    }
}
