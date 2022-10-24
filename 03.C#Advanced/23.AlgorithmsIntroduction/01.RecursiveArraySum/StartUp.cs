using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    public class StartUp
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = Sum(nums, 0);
            Console.WriteLine(sum);
        }

        static int Sum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
