using System;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double targetPlunder = int.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int day = 1; day <= days; day++)
            {
                totalPlunder += dailyPlunder;
                if (day % 3 == 0)
                {
                    totalPlunder += dailyPlunder / 2.0;
                }

                if (day % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }

            if (totalPlunder >= targetPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {totalPlunder / targetPlunder * 100:f2}% of the plunder.");
            }
        }
    }
}
