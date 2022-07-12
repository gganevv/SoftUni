using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOcurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word.ToLower()))
                {
                    wordsCount.Add(word.ToLower(), 0);
                }

                wordsCount[word.ToLower()]++;
            }

            List<string> result = wordsCount.Where(x => x.Value % 2 != 0).Select(x => x.Key).ToList();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
