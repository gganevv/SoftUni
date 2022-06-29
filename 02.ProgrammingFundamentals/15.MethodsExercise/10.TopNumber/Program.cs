using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());

            int n = 1;
            while (n <= maxNum)
            {
                CheckTopNum(n);
                n++;
            }
        }

        private static void CheckTopNum(int n)
        {
            bool sumOfDigitsDivisibleByEight = SumOfDigitsDivisibleByEight(n);
            bool holdAtLeastOneOddDigit = HoldAtLeastOneOddDigit(n);
            if (sumOfDigitsDivisibleByEight && holdAtLeastOneOddDigit)
            {
                Console.WriteLine(n);
            }
        }

        private static bool HoldAtLeastOneOddDigit(int n)
        {
            while (n > 1)
            {
                int digit = n % 10;
                if (digit % 2 != 0)
                {
                    return true;
                }
                n /= 10;
            }
            return false;
        }

        private static bool SumOfDigitsDivisibleByEight(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum % 8 == 0;
        }
    }
}
