using System;
using System.Collections.Generic;
using System.Linq;

class AppliedArithmetics
{
    static void Main()
    {
        Func<List<int>, List<int>> add = nums =>
        {
            List<int> arr = new List<int>();
            foreach (var num in nums)
            {
                arr.Add(num + 1);
            }
            return arr;
        };

        Func<List<int>, List<int>> multiply = nums =>
        {
            List<int> arr = new List<int>();
            foreach (var num in nums)
            {
                arr.Add(num * 2);
            }
            return arr;
        }; 
        
        Func<List<int>, List<int>> subtract = nums =>
        {
            List<int> arr = new List<int>();
            foreach (var num in nums)
            {
                arr.Add(num - 1);
            }
            return arr;
        };

        List<int> nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToList();

        string command = Console.ReadLine();
        while (command != "end")
        {
            switch (command)
            {
                case "add":
                    nums = add(nums);
                    break;
                case "multiply":
                    nums = multiply(nums);
                    break;
                case "subtract":
                    nums = subtract(nums);
                    break;
                case "print":
                    Console.WriteLine(string.Join(" ", nums));
                    break;
            }

            command = Console.ReadLine();
        }
    }
}