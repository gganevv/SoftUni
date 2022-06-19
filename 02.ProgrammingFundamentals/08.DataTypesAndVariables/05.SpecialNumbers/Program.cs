using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int currentNum = i;
                int sum = 0;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                }
                bool checkNum = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine($"{i} -> {checkNum}");
            }
        }
    }
}
