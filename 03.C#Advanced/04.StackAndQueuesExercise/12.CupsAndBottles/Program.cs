using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacityArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            LinkedList<int> cups = new LinkedList<int>(cupCapacityArr);
            Stack<int> bottles = new Stack<int>(bottlesArr);
            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                wastedWater = FillCup(cups, bottles, wastedWater);

            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static int FillCup(LinkedList<int> cups, Stack<int> bottles, int wastedWater)
        {
            int currentCup = cups.First();
            int currentBottle = bottles.Pop();
            currentCup -= currentBottle;
            if (currentCup <= 0)
            {
                cups.RemoveFirst();
            }
            else
            {
                cups.RemoveFirst();
                cups.AddFirst(currentCup);
            }
            if (currentCup < 0)
            {
                wastedWater += Math.Abs(currentCup);
            }

            return wastedWater;
        }
    }
}
