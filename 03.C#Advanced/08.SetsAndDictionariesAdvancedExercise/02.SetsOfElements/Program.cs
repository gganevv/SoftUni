using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < setsLength[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setsLength[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine($"{string.Join(" ", firstSet)}");
        }
    }
}
