using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> coffeDict = new Dictionary<string, int>()
            {
                { "Cortado", 0 },
                { "Espresso", 0 },
                { "Capuccino", 0},
                { "Americano", 0},
                { "Latte", 0}
            };

            List<int> coffeeList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            Queue<int> coffee = new Queue<int>();
            coffeeList.ForEach(x => coffee.Enqueue(x));

            List<int> milkList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            Stack<int> milk = new Stack<int>();
            milkList.ForEach(x => milk.Push(x));

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currentCoffee = coffee.Dequeue();
                int currentMilk = milk.Pop();
                bool coffeDone = MakeCoffee(currentCoffee, currentMilk, coffeDict);
                if (!coffeDone)
                {
                    milk.Push(currentMilk - 5);
                }
            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.Write("Coffee left: ");
            string coffePrint = coffee.Any() ? string.Join(", ", coffee) : "none";
            Console.WriteLine(coffePrint);

            Console.Write("Milk left: ");
            string milkPrint = milk.Any() ? string.Join(", ", milk) : "none";
            Console.WriteLine(milkPrint);

            coffeDict = coffeDict.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var cof in coffeDict)
            {
                if (cof.Value > 0)
                {
                    Console.WriteLine($"{cof.Key}: {cof.Value}");
                }
            }

        }

        private static bool MakeCoffee(int currentCoffee, int currentMilk, Dictionary<string, int> coffeDict)
        {
            int coffeMix = currentCoffee + currentMilk;
            switch (coffeMix)
            {
                case 50:
                    coffeDict["Cortado"]++;
                    return true;
                case 75:
                    coffeDict["Espresso"]++;
                    return true;
                case 100:
                    coffeDict["Capuccino"]++;
                    return true;
                case 150:
                    coffeDict["Americano"]++;
                    return true;
                case 200:
                    coffeDict["Latte"]++;
                    return true;
                default:
                    return false;
            }
        }
    }
}
