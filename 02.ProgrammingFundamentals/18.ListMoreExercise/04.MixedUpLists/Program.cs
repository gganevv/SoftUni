using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mixedList = new List<int>();
            List<int> result = new List<int>();
            int firstConst = 0;
            int secondConst = 0;

            if (firstList.Count > secondList.Count)
            {
                int lastIndex = firstList.Count - 1;
                firstConst = firstList[lastIndex];
                firstList.RemoveAt(lastIndex);
                lastIndex = firstList.Count - 1;
                secondConst = firstList[lastIndex];
                firstList.RemoveAt(lastIndex);
            }
            else
            {
                firstConst = secondList[0];
                secondList.RemoveAt(0);
                secondConst = secondList[0];
                secondList.RemoveAt(0);
            }

            for (int i = 0; i < firstList.Count; i++)
            {
                mixedList.Add(firstList[i]);
                mixedList.Add(secondList[secondList.Count - 1 - i]);
            }

            for (int i = 0; i < mixedList.Count; i++)
            {
                int element = mixedList[i];
                if (element > Math.Min(firstConst, secondConst) && element < Math.Max(firstConst, secondConst))
                {
                    result.Add(element);
                }
            }

            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
