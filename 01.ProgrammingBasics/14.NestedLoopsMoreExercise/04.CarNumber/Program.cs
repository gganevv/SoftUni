using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());

            for (int i = startingNum; i <= endingNum; i++)
            {
                for (int j = startingNum; j <= endingNum; j++)
                {
                    for (int k = startingNum; k <= endingNum; k++)
                    {
                        for (int l = startingNum; l <= endingNum; l++)
                        {
                            bool oddEven = (i % 2 == 0 && l % 2 != 0) || (i % 2 != 0 && l % 2 == 0);
                            bool firstBigger = i > l;
                            bool evenSum = (j + k) % 2 == 0;
                            if (oddEven && firstBigger && evenSum)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
