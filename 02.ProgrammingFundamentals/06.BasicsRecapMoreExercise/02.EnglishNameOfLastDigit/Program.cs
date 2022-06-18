using System;

namespace _02.EnglishNameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that returns the English spelling of the last digit of a
            //given number. Write a program that reads an integer and prints the
            //returned value from this method.

            int n = int.Parse(Console.ReadLine());
            string result = LastDigitToEnglish(n);
            Console.WriteLine(result);
        }

        private static string LastDigitToEnglish(int n)
        {
            int lastDigit = n % 10;
            switch (lastDigit)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "zero";
            }
        }
    }
}
