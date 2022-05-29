using System;

namespace _02.SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());
            int workDays = 365 - freeDays;
            int playMinutes = (freeDays * 127) + (workDays * 63);
            int diff = Math.Abs(30000 - playMinutes);
            int hours = diff / 60;
            int mins = diff % 60;
            if (playMinutes > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {mins} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {mins} minutes less for play");
            }
        }
    }
}
