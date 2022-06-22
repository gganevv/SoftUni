using System;
using System.Linq;

namespace _03.Roundingnumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            foreach (double num in nums)
            {
                Console.WriteLine($"{num} => {(int)Math.Round(num, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
