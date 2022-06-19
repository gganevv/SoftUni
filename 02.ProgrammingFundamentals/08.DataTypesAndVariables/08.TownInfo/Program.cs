using System;

namespace _08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            int townPopulation = int.Parse(Console.ReadLine());
            int townArea = int.Parse(Console.ReadLine());
            Console.WriteLine($"Town {townName} has population of {townPopulation} and area {townArea} square km.");
        }
    }
}
