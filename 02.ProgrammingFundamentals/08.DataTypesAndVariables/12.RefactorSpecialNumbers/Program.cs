using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int n = 1; n <= count; n++)
            {
                int sum = 0;
                int currentNum = n;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                }
                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", n, isSpecial);
            }

        }
    }
}
