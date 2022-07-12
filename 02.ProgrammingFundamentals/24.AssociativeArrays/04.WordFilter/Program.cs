using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            List<string> filteredWords = words.Where(x => x.Length % 2 == 0).ToList();
            filteredWords.ForEach (x => Console.WriteLine(x));
        }
    }
}
