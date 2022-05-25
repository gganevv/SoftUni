using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int mounts = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double sum = deposit + mounts * ((deposit * interest / 100) / 12);
            Console.WriteLine(sum);
        }
    }
}
