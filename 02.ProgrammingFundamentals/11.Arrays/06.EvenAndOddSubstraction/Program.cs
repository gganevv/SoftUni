using System;
using System.Linq;

namespace _06.EvenAndOddSubstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenSum = 0;
            int oddSum = 0;

            foreach (int n in nums)
            {
                if (n % 2 == 0)
                {
                    evenSum += n;
                }
                else
                {
                    oddSum += n;
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}
