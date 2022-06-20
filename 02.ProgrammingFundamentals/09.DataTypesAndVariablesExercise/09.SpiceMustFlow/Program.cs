using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MINNIMUM_SPICE = 100;
            const int SPICE_DECREESE = 10;
            const int CONSUMED_SPICE_BY_WORKERS = 26;

            int mineSpice = int.Parse(Console.ReadLine());
            int gatheredSpice = 0;
            int daysCount = 0;

            while (mineSpice >= MINNIMUM_SPICE)
            {
                gatheredSpice += mineSpice - CONSUMED_SPICE_BY_WORKERS;
                daysCount++;
                mineSpice -= SPICE_DECREESE;
            }

            if (gatheredSpice >= CONSUMED_SPICE_BY_WORKERS)
            {
                gatheredSpice -= CONSUMED_SPICE_BY_WORKERS;
            }

            Console.WriteLine(daysCount);
            Console.WriteLine(gatheredSpice);
        }
    }
}
