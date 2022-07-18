using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequences = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;

            for (int i = 0; i < sequences.Length; i++)
            {
                double currentSum = 0;
                char firstChar = sequences[i][0];
                char lastChar = sequences[i][sequences[i].Length - 1];
                double num = double.Parse(sequences[i].Substring(1, sequences[i].Length - 2));

                if (firstChar >= 65 && firstChar <= 90)
                {
                    currentSum += num / (firstChar - 64);
                }
                else
                {
                    currentSum += num * (firstChar - 96);
                }

                if (lastChar >= 65 && lastChar <= 90)
                {
                    currentSum -= lastChar - 64;
                }
                else
                {
                    currentSum += lastChar - 96;
                }

                totalSum += currentSum;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
