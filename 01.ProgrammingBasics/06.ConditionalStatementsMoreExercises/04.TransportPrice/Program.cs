using System;

namespace _04.TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kms = int.Parse(Console.ReadLine());
            string rate = Console.ReadLine();
            double totalPrice = 0;

            if (kms >= 100)
            {
                totalPrice += kms * 0.06;
            }
            else if (kms >= 20)
            {
                totalPrice += kms * 0.09;
            }
            else
            {
                double startingPrice = 0.7;
                if (rate == "day")
                {
                    totalPrice += startingPrice + 0.79 * kms;
                }
                else
                {
                    totalPrice += startingPrice + 0.9 * kms;
                }
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
