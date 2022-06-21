using System;

namespace _04.RefactorPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNum = int.Parse(Console.ReadLine());

            for (int num = 2; num <= lastNum; num++)
            {
                bool isPrime = true;
                for (int divisible = 2; divisible < num; divisible++)
                {
                    if (num % divisible == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{num} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}
