using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int sumNum = 0;
            while (sumNum < firstNum)
            {
                sumNum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sumNum);
        }
    }
}
