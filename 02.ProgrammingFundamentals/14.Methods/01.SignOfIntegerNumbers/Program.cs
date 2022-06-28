using System;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = CheckNumber(number);
            Console.WriteLine(result);
        }

        private static string CheckNumber(int number)
        {
            if (number > 0)
            {
                return $"The number {number} is positive. ";
            }
            else if (number < 0)
            {
                return $"The number {number} is negative. ";
            }
            else
            {
                return $"The number {number} is zero. ";
            }
        }
    }
}
