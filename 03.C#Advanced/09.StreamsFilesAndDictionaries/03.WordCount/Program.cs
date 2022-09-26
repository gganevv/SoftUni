using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordFilePath, string textFilePath, string outputFilePath)
        {
            string[] words;
            using (StreamReader seekWordsReader = new StreamReader(wordFilePath))
            {
                words = seekWordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            char[] separators = { ' ', '.', ',', '-', '?', '!', };
            string[] text;

            using (var reader = new StreamReader(textFilePath))
            {
                text = reader.ReadToEnd().Split(separators);
            }

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                wordsCount.Add(word, 0);
            }

            foreach (var word in text)
            {
                foreach (var seekWord in words)
                {
                    if (word.ToLower() == seekWord.ToLower())
                    {
                        wordsCount[seekWord]++;
                    }
                }
            }

            wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordsCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
