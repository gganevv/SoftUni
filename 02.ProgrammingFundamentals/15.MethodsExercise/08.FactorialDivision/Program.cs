using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double firstResult = GetFactorial(firstNum);
            double secondResult = GetFactorial(secondNum);

            double result = firstResult / secondResult;
            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int num)
        {
            double result = 1;
            while (num != 1)
            {
                result *= num;
                num--;
            }
            return result;
        }
    }
}