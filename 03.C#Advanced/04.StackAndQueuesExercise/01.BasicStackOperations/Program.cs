using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToPush = inputArgs[0];
            int elementsToPop = inputArgs[1];
            int elementToLook = inputArgs[2];

            int[] elementsToStack = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                nums.Push(elementsToStack[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                nums.Pop();
            }

            if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (nums.Contains(elementToLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}
