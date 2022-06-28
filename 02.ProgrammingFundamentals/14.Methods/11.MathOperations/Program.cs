using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = int.Parse(Console.ReadLine());
            string operat = Console.ReadLine();
            double secondNum = int.Parse(Console.ReadLine());

            double result = Calculate(firstNum, operat, secondNum);
            Console.WriteLine(result);
        }

        private static double Calculate(double firstNum, string operat, double secondNum)
        {
            double result = 0;
            switch (operat)
            {
                case "/":
                    result = firstNum / secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
