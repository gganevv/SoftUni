using System;
using System.Linq;

public class SortEvenNumbers
{
    static void Main()
    {
        Func<int, bool> filterNums = x => x % 2 == 0;

        int[] nums = Console.ReadLine()
            .Split(", ")
            .Select(x => int.Parse(x))
            .ToArray();

        int[] filteredNums = nums
            .Where(filterNums)
            .OrderBy(x => x)
            .ToArray();

        Console.WriteLine(String.Join(", ", filteredNums));
    }
}

