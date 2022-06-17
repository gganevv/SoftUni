using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        //Write a program that receives a single integer and calculates if it's strong
        //or not. A number is strong, if the sum of the factorials of each digit is
        //equal to the number itself.
        //Example: 145 is a strong number, because 1! + 4! + 5! = 145.
        //Print "yes", if the number is strong and "no", if the number is not strong.

            int num = int.Parse(Console.ReadLine());
            int originalNum = num;
            int factorialSum = 0;

            while (num > 0)
            {
                int digit = num % 10;
                num = num / 10;
                int currentFact = 1;
                for (int i = digit; i > 0; i--)
                {
                    currentFact *= i;
                }
                factorialSum += currentFact;
            }

            if (originalNum == factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
