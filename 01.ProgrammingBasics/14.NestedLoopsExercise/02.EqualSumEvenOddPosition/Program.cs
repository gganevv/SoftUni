using System;

namespace _02.EqualSumEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            for (int i = n1; i <= n2; i++)
            {
                string num = i.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for (int j = 0; j < num.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        oddSum += num[j];
                    }
                    else
                    {
                        evenSum += num[j];
                    }
                }
                if (oddSum == evenSum)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
