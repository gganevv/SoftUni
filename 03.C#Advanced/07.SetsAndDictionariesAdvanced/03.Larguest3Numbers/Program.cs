using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Larguest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            nums = nums.OrderByDescending(x => x).Take(3).ToList();

            foreach (var num in nums)
            {
                Console.Write(num + " ");
            }
        }
    }
}
