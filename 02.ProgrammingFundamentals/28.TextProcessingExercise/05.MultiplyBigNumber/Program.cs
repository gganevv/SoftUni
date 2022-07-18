using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            StringBuilder result = new StringBuilder();
            int remainder = 0;

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                int currentNumAsDigit = int.Parse(firstNum[i].ToString());
                int currentResult = currentNumAsDigit * secondNum + remainder;
                remainder = currentResult / 10;
                currentResult %= 10;

                sb.Append(currentResult);
            }

            if (remainder > 0)
            {
                sb.Append(remainder);
            }

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                result.Append(sb[i]);
            }

            Console.WriteLine(result);
        }
    }
}
