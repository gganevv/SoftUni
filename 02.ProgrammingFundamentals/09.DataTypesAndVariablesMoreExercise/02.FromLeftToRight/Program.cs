using System;

namespace _02.FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] numbers = Console.ReadLine().Split(" ");
                long firstNum = long.Parse(numbers[0]);
                long secondNum = long.Parse(numbers[1]);
                long sum = 0;
                long biggerNum = Math.Abs(firstNum > secondNum ? firstNum : secondNum);
                while (biggerNum > 0)
                {
                    sum += biggerNum % 10;
                    biggerNum /= 10;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
