using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    public class StartUp
    {
        static void Main()
        {
            int maxCaffeine = 300;
            int takenCaffeine = 0;
            Stack<int> caffeine = new Stack<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToList());
            Queue<int> energyDrinks = new Queue<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToList());

            while (caffeine.Any() && energyDrinks.Any())
            {
                int currentCaffeine = caffeine.Pop();
                int currentEnergyDrink = energyDrinks.Dequeue();

                int totalCaffeine = currentCaffeine * currentEnergyDrink;

                if (totalCaffeine <= maxCaffeine)
                {
                    maxCaffeine -= totalCaffeine;
                    takenCaffeine += totalCaffeine;
                }
                else
                {
                    energyDrinks.Enqueue(currentEnergyDrink);
                    if (takenCaffeine >= 30)
                    {
                        takenCaffeine -= 30;
                        maxCaffeine += 30;
                    }
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {takenCaffeine} mg caffeine.");
        }
    }
}
