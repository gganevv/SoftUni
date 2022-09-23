using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char currnetC = text[i];
                if (!chars.ContainsKey(currnetC))
                {
                    chars.Add(currnetC, 0);
                }
                chars[currnetC]++;
            }

            foreach (var c in chars)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
