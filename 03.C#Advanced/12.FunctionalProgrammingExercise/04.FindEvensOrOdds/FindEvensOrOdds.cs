using System;
using System.Collections.Generic;
using System.Linq;
class FindEvensOrOdds
{
    static void Main()
    {
        Predicate<int> isOdd = number => number % 2 != 0;
        Predicate<int> isEven = number => number % 2 == 0;

        int[] ranges = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int lowerRange = ranges[0];
        int upperRange = ranges[1];

        List<int> nums = Enumerable.Range(lowerRange, upperRange - lowerRange + 1).ToList();

        string condition = Console.ReadLine();
        List<int> filteredNumbers = new List<int>();

        if (condition == "odd")
        {
            filteredNumbers = nums.FindAll(isOdd);
        }
        else
        {
            filteredNumbers = nums.FindAll(isEven);
        }

        Console.WriteLine(string.Join(" ", filteredNumbers));
    }
}