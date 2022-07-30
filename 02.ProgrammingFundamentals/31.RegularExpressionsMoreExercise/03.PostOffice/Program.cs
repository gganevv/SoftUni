using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> decryptedWords = new List<string>();

            string[] lines = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            string capitalLettersPattern = @"([#$%*&])(?<cl>[A-Z]{1,})\1";
            string startingLetterAndLengthPattern = @"(?<ch>\d{2}):(?<length>\d{2})";

            char[] capitalLetters = Regex.Match(lines[0], capitalLettersPattern).Groups["cl"].Value.ToCharArray();
            var startAndLength = Regex.Matches(lines[1], startingLetterAndLengthPattern);
            string[] words = lines[2].Split();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < capitalLetters.Length; j++)
                {
                    for (int k = 0; k < startAndLength.Count; k++)
                    {
                        char ch = (char)int.Parse(startAndLength[k].Groups["ch"].Value);
                        int length = int.Parse(startAndLength[k].Groups["length"].Value);
                        if (words[i][0] == capitalLetters[j] && words[i][0] == ch && words[i].Length == length + 1 && !decryptedWords.Contains(words[i]))
                        {
                            decryptedWords.Add(words[i]);
                        }
                    }
                }
            }

            decryptedWords.ForEach(Console.WriteLine);
        }
    }
}
