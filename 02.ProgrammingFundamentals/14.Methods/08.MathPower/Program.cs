using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNum = double.Parse(Console.ReadLine());
            double powerNum = double.Parse(Console.ReadLine());

            double result = CalculatePower(baseNum, powerNum);
            Console.WriteLine(result);
        }

        private static double CalculatePower(double baseNum, double powerNum)
        {
            double sum = 1;
            for (int i = 0; i < powerNum; i++)
            {
                sum *= baseNum;
            }

            return sum;
        }
    }
}
