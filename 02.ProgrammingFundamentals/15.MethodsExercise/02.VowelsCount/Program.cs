using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            PrintVowels(word);
        }

        private static void PrintVowels(string word)
        {
            int counter = 0;
            foreach (char ch in word)
            {
                if ("aeiou".Contains(ch))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
