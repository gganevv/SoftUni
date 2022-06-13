using System;

namespace _02.LettersCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            char combinationStart = char.Parse(Console.ReadLine());
            char combinationEnd = char.Parse(Console.ReadLine());
            char ignoredChar = char.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = combinationStart; i <= combinationEnd; i++)
            {
                for (int j = combinationStart; j <= combinationEnd; j++)
                {
                    for (int k = combinationStart; k <= combinationEnd; k++)
                    {
                        if (i != ignoredChar && j != ignoredChar && k != ignoredChar)
                        {
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
