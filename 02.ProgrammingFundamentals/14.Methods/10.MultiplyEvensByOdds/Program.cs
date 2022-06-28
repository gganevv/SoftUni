using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = GetMultipleOfEvenAndOdds(Math.Abs(number));
            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int number)
        {
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            return evenSum * oddSum;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int currentNum = number % 10;
                if (currentNum % 2 != 0)
                {
                    sum += currentNum;
                }
                number /= 10;
            }
            return sum;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int currentNum = number % 10;
                if (currentNum % 2 == 0)
                {
                    sum += currentNum;
                }
                number /= 10;
            }
            return sum;
        }
    }
}
