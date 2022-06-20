using System;

namespace _01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourtNum = int.Parse(Console.ReadLine());

            int result = (firstNum + secondNum) / thirdNum * fourtNum;
            Console.WriteLine(result);
        }
    }
}
