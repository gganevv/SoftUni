using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char lastCh = word[0];
            StringBuilder sb = new StringBuilder();
            sb.Append(lastCh);

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] != lastCh)
                {
                    sb.Append(word[i]);
                }
                lastCh = word[i];
            }

            Console.WriteLine(sb);
        }
    }
}
