using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            string result = FindSign(firstNum, secondNum, thirdNum);
            Console.WriteLine(result);
        }

        private static string FindSign(int firstNum, int secondNum, int thirdNum)
        {
            int result = firstNum * secondNum * thirdNum;
            if (result < 0)
            {
                return "negative";
            }
            else if (result > 0)
            {
                return "positive";
            }
            else
            {
                return "zero";
            }
        }
    }
}
