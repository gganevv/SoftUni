using System;

namespace _06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kms = double.Parse(Console.ReadLine());
            double price = 0;

            if (kms <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    price = 0.75 * kms * 4; 
                }
                else if (season == "Summer")
                {
                    price = 0.9 * kms * 4;
                }
                else
                {
                    price = 1.05 * kms * 4;
                }
            }
            else if (kms > 5000 && kms <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    price = 0.95 * kms * 4;
                }
                else if (season == "Summer")
                {
                    price = 1.1 * kms * 4;
                }
                else
                {
                    price = 1.25 * kms * 4;
                }
            }
            else if (kms > 10000 && kms <= 20000)
            {
                price = 1.45 * kms * 4;
            }

            price *= 0.9;
            Console.WriteLine($"{price:f2}");
        }
    }
}
