using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] upperArray = new int[nums.Length / 2];
            int[] lowerArray = new int[nums.Length / 2];
            int[] tempArray = new int[nums.Length / 4];

            for (int i = nums.Length / 4, j = 0; i < nums.Length - nums.Length / 4; i++, j++)
            {
                lowerArray[j] = nums[i];
            }

            for (int i = 0; i < nums.Length / 4; i++)
            {
                tempArray[i] = nums[i];
            }

            Array.Reverse(tempArray);

            for (int i = 0; i < tempArray.Length; i++)
            {
                upperArray[i] = tempArray[i];
            }

            for (int i = nums.Length / 2 + tempArray.Length, j = 0; i < nums.Length; i++, j++)
            {
                tempArray[j] = nums[i];
            }

            Array.Reverse(tempArray);

            for (int i = nums.Length / 2 + tempArray.Length, j = 0; i < nums.Length; i++, j++)
            {
                tempArray[j] = nums[i];
            }

            Array.Reverse(tempArray);

            for (int i = nums.Length / 4, j = 0; i < upperArray.Length; i++, j++)
            {
                upperArray[i] = tempArray[j];
            }

            for (int i = 0; i < upperArray.Length; i++)
            {
                Console.Write($"{upperArray[i] + lowerArray[i]} ");
            }
        }
    }
}
