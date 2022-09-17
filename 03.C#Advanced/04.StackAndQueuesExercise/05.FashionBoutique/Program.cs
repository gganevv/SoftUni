using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesToStack = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesToStack);
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCounter = 1;
            int currentRack = 0;

            while (clothes.Count > 0)
            {
                int currentCloth = clothes.Peek();
                if (currentRack + currentCloth <= rackCapacity)
                {
                    currentRack += clothes.Pop();
                }
                else
                {
                    rackCounter++;
                    currentRack = 0;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
