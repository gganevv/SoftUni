using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int[] firstArr = new int[numberOfLines];
            int[] secondArr = new int[numberOfLines];
            for (int i = 0; i < numberOfLines; i++)
            {
                int[] tempArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    firstArr[i] = tempArray[0];
                    secondArr[i] = tempArray[1];
                }
                else
                {
                    firstArr[i] = tempArray[1];
                    secondArr[i] = tempArray[0];
                }
            }

            Console.WriteLine(String.Join(" ", firstArr));
            Console.WriteLine(String.Join(" ", secondArr));
        }
    }
}
