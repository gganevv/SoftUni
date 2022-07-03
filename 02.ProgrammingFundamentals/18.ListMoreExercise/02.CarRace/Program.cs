using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine().Split().Select(int.Parse).ToList();
            double leftTime = 0; double rightTime = 0;

            for (int i = 0; i < times.Count / 2; i++)
            {
                leftTime += times[i];
                rightTime += times[times.Count - i - 1];

                if (times[i] == 0) leftTime *= 0.8;
                if (times[times.Count - i - 1] == 0) rightTime *= 0.8;
            }
            string winner = leftTime < rightTime ? "left" : "right";
            double totalTime = leftTime < rightTime ? leftTime : rightTime;
            Console.WriteLine($"The winner is {winner} with total time: {totalTime}");
        }
    }
}
