using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    public class StartUp
    {
        static void Main()
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            Dictionary<string, int> usedTiles = CreateDictionary();

            while (whiteTiles.Any() && greyTiles.Any())
            {
                int greyTile = greyTiles.Dequeue();
                int whiteTile = whiteTiles.Pop();

                if (whiteTile == greyTile)
                {
                    CheckArea(whiteTile + greyTile, usedTiles);
                }
                else
                {
                    whiteTiles.Push(whiteTile / 2);
                    greyTiles.Enqueue(greyTile);
                }
            }

            string whiteTilesPrint = whiteTiles.Any() ? $"{string.Join(", ", whiteTiles)}" : "none";
            Console.WriteLine($"White tiles left: {whiteTilesPrint}");

            string greyTilesPrint = greyTiles.Any() ? $"{string.Join(", ", greyTiles)}" : "none";
            Console.WriteLine($"Grey tiles left: {greyTilesPrint}");

            usedTiles = usedTiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var tile in usedTiles)
            {
                if (tile.Value > 0)
                {
                    Console.WriteLine($"{tile.Key}: {tile.Value}");
                }
            }
        }

        private static void CheckArea(int area, Dictionary<string, int> usedTiles)
        {
            switch (area)
            {
                case 40:
                    usedTiles["Sink"]++;
                    break;
                case 50:
                    usedTiles["Oven"]++;
                    break;
                case 60:
                    usedTiles["Countertop"]++;
                    break;
                case 70:
                    usedTiles["Wall"]++;
                    break;
                default:
                    usedTiles["Floor"]++;
                    break;
            }
        }

        static Dictionary<string, int> CreateDictionary()
        {
            return new Dictionary<string, int>()
                {
                    { "Sink", 0 },
                    { "Oven", 0 },
                    { "Countertop", 0},
                    { "Wall", 0 },
                    { "Floor", 0 }
                };
        }
    }
}
