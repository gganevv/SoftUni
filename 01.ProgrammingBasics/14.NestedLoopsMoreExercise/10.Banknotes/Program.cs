using System;

namespace _10.Banknotes
{
    class Program
    {
        static void Main(string[] args)
        {
            int coinsOne = int.Parse(Console.ReadLine());
            int coinsTwo = int.Parse(Console.ReadLine());
            int coinsFive = int.Parse(Console.ReadLine());
            int desiredMoney = int.Parse(Console.ReadLine());

            for (int i = 0; i <= coinsOne; i++)
            {
                for (int j = 0; j <= coinsTwo; j++)
                {
                    for (int k = 0; k <= coinsFive; k++)
                    {
                        if (1 * i + 2 * j + 5 * k == desiredMoney)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {desiredMoney} lv.");
                        }
                    }
                }
            }
        }
    }
}
