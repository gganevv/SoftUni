using System;

namespace _05.DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string digits = string.Empty;
            string letters = string.Empty;
            string other = string.Empty;

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits += text[i];
                }
                else if (char.IsLetter(text[i]))
                {
                    letters += text[i];
                }
                else
                {
                    other += text[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
