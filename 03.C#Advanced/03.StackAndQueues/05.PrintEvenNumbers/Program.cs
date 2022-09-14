using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> nums = new Queue<int>(input);
            List<int> evenNumbers = new List<int>();

            while (nums.Count > 0)
            {
                int currentNum = nums.Dequeue();
                if (currentNum % 2 == 0)
                {
                    evenNumbers.Add(currentNum);
                }
            }

            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
