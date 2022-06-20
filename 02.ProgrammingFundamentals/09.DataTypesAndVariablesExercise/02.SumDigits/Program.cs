using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum += int.Parse(n[i].ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
