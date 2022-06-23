using System;
using System.Linq;

namespace _08.MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int firstNum = nums[i];
                    int secondNum = nums[j];
                    if (firstNum + secondNum == magicSum)
                    {
                        Console.WriteLine($"{firstNum} {secondNum}");
                    }
                }
            }
        }
    }
}
