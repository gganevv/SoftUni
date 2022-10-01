using System;
using System.Collections.Generic;
using System.Linq;

class ListOfPredicates
{
    static void Main()
    {
        List<Predicate<int>> predicates = new List<Predicate<int>>();

        int endRange = int.Parse(Console.ReadLine());
        HashSet<int> dividers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToHashSet();

        int[] nums = Enumerable.Range(1, endRange).ToArray();

        foreach (int div in dividers)
        {
            predicates.Add(x => x % div == 0);
        }

        foreach (var num in nums)
        {
            bool isDivisible = true;

            foreach (var match in predicates)
            {
                if (!match(num))
                {
                    isDivisible = false; 
                    break;
                }
            }

            if (isDivisible)
            {
                Console.Write($"{num} ");
            }
        }
    }
}