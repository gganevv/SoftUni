using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int digitsSum = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                char c = char.Parse(Console.ReadLine());
                digitsSum += c;
            }

            Console.WriteLine($"The sum equals: {digitsSum}");
        }
    }
}
