using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < n.Length; i++)
            {
                int currentN = n[i];
                if (!numbers.ContainsKey(currentN))
                {
                    numbers.Add(currentN, 0);
                }
                numbers[currentN]++;
            }

            foreach (var d in numbers)
            {
                if (d.Value % 2 != 0)
                {
                    Console.WriteLine(d.Key);
                }
            }
        }
    }
}
