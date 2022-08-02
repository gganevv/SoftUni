using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> coolEmojis = new List<string>();
            BigInteger treshhold = 1;
            string emojisPattern = @"(?<prefix>:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            int emojiCounter = 0;

            var digits = Regex.Matches(input, digitsPattern);
            for (int i = 0; i < digits.Count; i++)
            {
                treshhold *= int.Parse(digits[i].Value);
            }

            var emojis = Regex.Matches(input, emojisPattern);
            for (int i = 0; i < emojis.Count; i++)
            {
                emojiCounter++;
                string currentEmoji = emojis[i].Groups["emoji"].Value;
                string prefix = emojis[i].Groups["prefix"].Value;
                int currentValue = 0;

                for (int k = 0; k < currentEmoji.Length; k++)
                {
                    currentValue += currentEmoji[k];
                }
                if (currentValue > treshhold)
                {
                    coolEmojis.Add(prefix + currentEmoji + prefix);
                }
            }

            Console.WriteLine($"Cool threshold: {treshhold}");
            Console.WriteLine($"{emojiCounter} emojis found in the text. The cool ones are:");
            coolEmojis.ForEach(Console.WriteLine);

        }
    }
}
