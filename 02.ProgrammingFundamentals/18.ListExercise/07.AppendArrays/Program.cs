using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            string[] arrays = input.Split("|");
            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                List<int> arrNums = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                numbers.AddRange(arrNums);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
