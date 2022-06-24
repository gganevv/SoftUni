using System;
using System.Collections.Generic;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static Dictionary<int, long> MEMO = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long result = GetFibonacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (MEMO.ContainsKey(n))
            {
                return MEMO[n];
            }
            if (n <= 2)
            {
                return 1;
            }
            long value = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            MEMO[n] = value;
            return value;
        }
    }
}
