using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    public class StartUp
    {
        static void Main()
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList());
            List<string> wordsFound = new List<string>();
            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>()
            {
                { "pear", new HashSet<char>() },
                { "flour", new HashSet<char>() },
                { "pork", new HashSet<char>() },
                { "olive", new HashSet<char>() }
            };

            while (consonants.Any())
            {
                char consonant = consonants.Pop();
                char vowel = vowels.Dequeue();

                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        words[word.Key].Add(vowel);
                    }
                    if (word.Key.Contains(consonant))
                    {
                        words[word.Key].Add(consonant);
                    }
                }

                vowels.Enqueue(vowel);
            }

            foreach (var word in words)
            {
                if (word.Key.Length == word.Value.Count)
                {
                    wordsFound.Add(word.Key);
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            wordsFound.ForEach(x => Console.WriteLine(x));
        }
    }
}
