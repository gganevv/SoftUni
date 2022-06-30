using System;
using System.Collections.Generic;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            FindNTribonacci(n, nums);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static void FindNTribonacci(int n, List<int> nums)
        {
            if (n == 1)
            {
                nums.Add(1);
            }
            else if (n == 2)
            {
                nums.Add(1);
                nums.Add(1);
            }
            else if (n >= 3)
            {
                nums.Add(1);
                nums.Add(1);
                nums.Add(2);
            }

            for (int i = 3; i < n; i++)
            {
                int currentNum = nums[i - 3] + nums[i - 2] + nums[i - 1];
                nums.Add(currentNum);
            }
        }
    }
}
