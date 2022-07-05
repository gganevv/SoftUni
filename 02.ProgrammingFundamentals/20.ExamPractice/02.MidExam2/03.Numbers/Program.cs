using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> topNumbers = new List<int>();
            double avg = 1.0 * numbers.Sum() / numbers.Count();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > avg)
                {
                    topNumbers.Add(numbers[i]);
                }
            }

            List<int> sortedNumbers = topNumbers.OrderByDescending(i => i).ToList();
            if (sortedNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
            Console.WriteLine(string.Join(" ", sortedNumbers.Take(5)));
            }
        }
    }
}
