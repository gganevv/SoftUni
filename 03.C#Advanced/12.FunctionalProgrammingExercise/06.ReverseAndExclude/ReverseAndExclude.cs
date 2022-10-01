using System;
using System.Collections.Generic;
using System.Linq;

class ReverseAndExclude
{
    static void Main()
    {
        Func<List<int>, List<int>> reverseNums = nums =>
        {
            var list = new List<int>();
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                list.Add(nums[i]);
            }
            return list;
        };

        Func<List<int>, Predicate<int>, List<int>> filterNumbers = (numbers, match) =>
        {
            List<int> result = new List<int>();

            foreach (int num in numbers)
            {
                if (!match(num))
                {
                    result.Add(num);
                }
            }

            return result;
        };

        List<int> nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToList();
        int divider = int.Parse(Console.ReadLine());

        nums = filterNumbers(nums, n => n % divider == 0);
        nums = reverseNums(nums);

        Console.WriteLine(string.Join(" ", nums));
    }
}