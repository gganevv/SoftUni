using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                bool topInt = true;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] <= nums[j])
                    {
                        topInt = false;
                        break;
                    }
                }
                if (topInt)
                {
                    Console.Write(nums[i] + " ");
                }
            }
        }
    }
}
