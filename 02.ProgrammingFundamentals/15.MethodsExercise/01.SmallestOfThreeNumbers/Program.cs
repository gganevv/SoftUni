using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            PrintSmallestNum(firstNum, secondNum, thirdNum);
        }

        private static void PrintSmallestNum(int firstNum, int secondNum, int thirdNum)
        {
            Console.WriteLine(Math.Min(firstNum, Math.Min(secondNum, thirdNum)));
        }
    }
}
