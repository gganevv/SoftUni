using System;
using System.Linq;

class CustomMinFunction
{
    static void Main()
    {
        Func<int[], int> getMinNumber = (nums) =>
        {
            int minNum = int.MaxValue;
            foreach (var n in nums)
            {
                if (n < minNum)
                {
                    minNum = n;
                }
            }

            return minNum;
        };

        int[] nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int minNum = getMinNumber(nums);
        Console.WriteLine(minNum);
    }
}