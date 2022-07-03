using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string text = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    index += int.Parse(numbers[i][j].ToString());
                }

                while (index > text.Length)
                {
                    index -= text.Length;
                }

                result += text[index];
                text = text.Substring(0, index) + text.Substring(index + 1);
            }

            Console.WriteLine(result);
        }
    }
}
