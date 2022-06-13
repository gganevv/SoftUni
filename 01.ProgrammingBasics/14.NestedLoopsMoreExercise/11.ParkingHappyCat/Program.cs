using System;

namespace _11.ParkingHappyCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalMoney = 0;
            double fee = 1;

            for (int i = 1; i <= days; i++)
            {
                double dayMoney = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        fee = 2.5;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        fee = 1.25;
                    }
                    dayMoney += fee;
                    fee = 1;
                }
                Console.WriteLine($"Day: {i} - {dayMoney:f2} leva");
                totalMoney += dayMoney;
            }
            Console.WriteLine($"Total: {totalMoney:f2} leva");
        }
    }
}
