using System;
using System.Collections.Generic;

namespace _01.CountCharInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            char[] text = Console.ReadLine().ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                char currentCh = text[i];
                if (currentCh != ' ')
                {
                    if (!chars.ContainsKey(currentCh))
                    {
                        chars[currentCh] = 0;
                    }
                    
                    chars[currentCh]++;
                }
            }

            foreach (var c in chars)
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }
        }
    }
}
