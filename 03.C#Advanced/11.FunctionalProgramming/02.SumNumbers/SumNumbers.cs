using System;
using System.Linq;

public class SumNumbers
{
    static void Main(string[] args)
    {
        Func<int[], int> countNumbers = x => x.Length;
        
        int[] nums = Console.ReadLine()
            .Split(", ")
            .Select(x => int.Parse(x))
            .ToArray();

        Console.WriteLine(countNumbers(nums));
        Console.WriteLine(nums.Sum());
    }
}