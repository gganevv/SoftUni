using System;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string result = string.Empty;
            int power = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (currentChar == '>')
                {
                    power += int.Parse(word[i + 1].ToString()) + 1;
                    result += '>';
                }

                if (power == 0)
                {
                    result += currentChar;
                }
                else
                {
                    power--;
                }
            }

            Console.WriteLine(result);
        }
    }
}
