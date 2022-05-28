using System;

namespace _03.Time_15Mins
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int totalTimeInMins = minutes + hours * 60;
            int timeResult = totalTimeInMins + 15;

            int resultHours = timeResult / 60;
            int resultMins = timeResult % 60;
            if (resultHours > 23)
            {
                resultHours = 0;
            }
            if (resultMins < 10)
            {
                Console.WriteLine($"{resultHours}:0{resultMins}");
            }
            else
            {
                Console.WriteLine($"{resultHours}:{resultMins}");
            }
        }
    }
}
