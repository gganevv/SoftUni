using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string addedMoney = Console.ReadLine();
            double balance = 0;
            while (addedMoney != "NoMoreMoney")
            {
                double increase = double.Parse(addedMoney);
                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balance += increase;
                Console.WriteLine($"Increase: {increase:f2}");
                addedMoney = Console.ReadLine();
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
