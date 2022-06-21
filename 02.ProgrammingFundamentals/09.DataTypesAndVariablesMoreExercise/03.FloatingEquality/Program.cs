using System;

namespace _03.FloatingEquality
{
    class Program
    {
        private const decimal EPS = 0.000001M;
        static void Main(string[] args)
        {
            decimal firstNum = decimal.Parse(Console.ReadLine());
            decimal secondNum = decimal.Parse(Console.ReadLine());

            decimal diff = Math.Abs(firstNum - secondNum);
            if (diff >= EPS)
            {
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(true);
            }
        }
    }
}
