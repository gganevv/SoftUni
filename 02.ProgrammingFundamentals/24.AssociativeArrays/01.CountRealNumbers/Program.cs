using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                if (!counts.ContainsKey(currentNum))
                {
                    counts.Add(currentNum, 0);
                }

                counts[currentNum]++;
            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}
