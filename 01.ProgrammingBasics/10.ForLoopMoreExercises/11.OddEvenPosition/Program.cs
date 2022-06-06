using System;

namespace _11.OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddSum += currentNum;
                    if (currentNum < oddMin)
                    {
                        oddMin = currentNum;
                    }
                    if (currentNum > oddMax)
                    {
                        oddMax = currentNum;
                    }
                }
                else
                {
                    evenSum += currentNum;
                    if (currentNum < evenMin)
                    {
                        evenMin = currentNum;
                    }
                    if (currentNum > evenMax)
                    {
                        evenMax = currentNum;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");
            Console.WriteLine(oddMin < double.MaxValue ? $"OddMin={oddMin:f2}," : "OddMin=No,");
            Console.WriteLine(oddMax > double.MinValue ? $"OddMax={oddMax:f2}," : "OddMax=No,");

            Console.WriteLine($"EvenSum={evenSum:f2},");
            Console.WriteLine(evenMin < double.MaxValue ? $"EvenMin={evenMin:f2}," : "EvenMin=No,");
            Console.WriteLine(evenMax > double.MinValue ? $"EvenMax={evenMax:f2}" : "EvenMax=No");
        }
    }
}
