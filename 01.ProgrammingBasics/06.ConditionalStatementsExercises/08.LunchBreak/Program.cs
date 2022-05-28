using System;

namespace _08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int episodeLength = int.Parse(Console.ReadLine());
            int lunchTime = int.Parse(Console.ReadLine());

            double eatingTime = lunchTime / 8.0;
            double restTime = lunchTime / 4.0;
            double timeLeft = lunchTime - eatingTime - restTime;
            double diff = timeLeft - episodeLength;

            if (diff >= 0)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(diff)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(Math.Abs(diff))} more minutes.");
            }
        }
    }
}
