using System;

namespace _08.OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMins = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMins = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMins;
            int arrivalTime = arrivalHour * 60 + arrivalMins;

            int diff = Math.Abs(examTime - arrivalTime);
            int diffMins = Math.Abs(diff % 60);
            int diffHours = Math.Abs(diff / 60);

            if (arrivalTime > examTime)
            {
                Console.WriteLine("Late");
                if (diff >= 60)
                {
                    Console.WriteLine($"{diffHours}:{diffMins.ToString("00")} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{diffMins} minutes after the start");
                }
            }
            else if (arrivalTime < examTime - 30)
            {
                Console.WriteLine("Early");
                if (diff >= 60)
                {
                    Console.WriteLine($"{diffHours}:{diffMins.ToString("00")} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{diffMins} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                if (diff >= 60)
                {
                    Console.WriteLine($"{diffHours}:{diffMins.ToString("00")} hours before the start");
                }
                else if (diff > 0)
                {
                    Console.WriteLine($"{diffMins} minutes before the start");
                }
            }


        }
    }
}
