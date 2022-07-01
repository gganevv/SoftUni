using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main()
        {
            List<int> firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> finalNumbers = new List<int>();

            int minLength = Math.Min(firstNumbers.Count, secondNumbers.Count);
            for (int i = 0; i < minLength; i++)
            {
                finalNumbers.Add(firstNumbers[i]);
                finalNumbers.Add(secondNumbers[i]);
            }

            if (firstNumbers.Count > secondNumbers.Count)
            {
                for (int i = minLength; i < firstNumbers.Count; i++)
                {
                    finalNumbers.Add(firstNumbers[i]);
                }
            }
            else if (secondNumbers.Count > firstNumbers.Count)
            {
                for (int i = minLength; i < secondNumbers.Count; i++)
                {
                    finalNumbers.Add(secondNumbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", finalNumbers));
        }
    }
}
