using System;
using System.Collections.Generic;
using System.Linq;

public class BaristaContest
{
    static void Main()
    {
        Dictionary<string, int> coffeDict = HardcodeDictionary();
        Queue<int> coffee = FillCoffeeQueue();
        Stack<int> milk = FillMilkStack();

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

        PrintWinOrLose(coffee, milk);
        PrintLefover(coffee, milk);

        coffeDict = coffeDict.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        foreach (var cof in coffeDict)
        {
            if (cof.Value > 0)
            {
                Console.WriteLine($"{cof.Key}: {cof.Value}");
            }
        }

    }

    private static void PrintLefover(Queue<int> coffee, Stack<int> milk)
    {
        Console.Write("Coffee left: ");
        string coffePrint = coffee.Any() ? string.Join(", ", coffee) : "none";
        Console.WriteLine(coffePrint);

        Console.Write("Milk left: ");
        string milkPrint = milk.Any() ? string.Join(", ", milk) : "none";
        Console.WriteLine(milkPrint);
    }

    private static void PrintWinOrLose(Queue<int> coffee, Stack<int> milk)
    {
        if (coffee.Count == 0 && milk.Count == 0)
        {
            Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
        }
        else
        {
            Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
        }
    }

    private static Stack<int> FillMilkStack()
    {
        Stack<int> milk = new Stack<int>();

        List<int> milkList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
        milkList.ForEach(x => milk.Push(x));
        return milk;
    }

    private static Queue<int> FillCoffeeQueue()
    {
        Queue<int> coffee = new Queue<int>();
        List<int> coffeeList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
        coffeeList.ForEach(x => coffee.Enqueue(x));
        return coffee;
    }

    private static Dictionary<string, int> HardcodeDictionary() // :(
    {
        return new Dictionary<string, int>()
            {
                { "Cortado", 0 },
                { "Espresso", 0 },
                { "Capuccino", 0},
                { "Americano", 0},
                { "Latte", 0}
            };
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