using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToEnqueue = inputArgs[0];
            int elementsToDequeue = inputArgs[1];
            int elementToLook = inputArgs[2];
            int[] startingElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            Queue<int> nums = new Queue<int>();
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                nums.Enqueue(startingElements[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                nums.Dequeue();
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
