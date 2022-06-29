using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int addResult = Add(firstNum, secondNum);
            int subtractResult = Subtract(addResult, thirdNum);
            Console.WriteLine(subtractResult);
        }

        private static int Subtract(int addResult, int thirdNum) => addResult - thirdNum;
        private static int Add(int firstNum, int secondNum) => firstNum + secondNum;
    }
}
