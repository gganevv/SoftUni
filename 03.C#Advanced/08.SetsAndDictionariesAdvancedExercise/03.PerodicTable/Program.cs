using System;
using System.Collections.Generic;

namespace _03.PerodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < countOfLines; i++)
            {
                string[] lineElements = Console.ReadLine().Split(' ');
                elements.UnionWith(lineElements);
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
