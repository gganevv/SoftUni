using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string wordsPattern = @"([@#])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            Dictionary<string, string> words = new Dictionary<string, string>();
            var matches = Regex.Matches(input, wordsPattern);

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;
                string reversedSecondWord = new string(secondWord.Reverse().ToArray());
                if (firstWord == reversedSecondWord)
                {
                    words.Add(firstWord, secondWord);
                }
            }

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (words.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                StringBuilder sb = new StringBuilder();
                foreach (var w in words)
                {
                    sb.Append($"{w.Key} <=> {w.Value}, ");
                }
                sb.Remove(sb.Length - 2, 1);
                Console.WriteLine(sb.ToString().Trim());
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
