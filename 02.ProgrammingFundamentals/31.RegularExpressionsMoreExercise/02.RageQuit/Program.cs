using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string nonDigitsPattern = @"[^\d]+";
            string digitsPattern = @"[\d]+";
            List<char> uniqueChars = new List<char>();
            
            var nonDigits = Regex.Matches(input, nonDigitsPattern);
            var digits = Regex.Matches(input, digitsPattern);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < digits.Count; i++)
            {
                string currentResult = string.Empty;
                int currentCount = int.Parse(digits[i].Value);
                for (int j = 0; j < currentCount; j++)
                {
                    result.Append(nonDigits[i].Value);
                }
            }
            foreach (char ch in result.ToString())
            {
                if ((ch > '9' || ch < '0') && !uniqueChars.Contains(ch))  // FUCK YOU!!!
                {
                    uniqueChars.Add(ch);
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueChars.Count}");
            Console.WriteLine(result);
        }
    }
}
