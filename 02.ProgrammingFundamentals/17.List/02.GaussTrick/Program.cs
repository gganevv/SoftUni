using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int originalCount = numbers.Count;

            for (int i = 0; i < originalCount / 2; i++)
            {
                numbers[i] += numbers[originalCount - i - 1];
                numbers.RemoveAt(originalCount - i - 1);

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
