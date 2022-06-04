using System;

namespace _09.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int seqLength = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < seqLength; i++)
            {
                leftSum += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < seqLength; i++)
            {
                rightSum += int.Parse(Console.ReadLine());
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
