using System;

namespace _06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeEachMeter = double.Parse(Console.ReadLine());

            double time = distance * timeEachMeter;
            double delay = Math.Floor(distance / 15) * 12.5;
            double ivanchoTime = time + delay;

            if (ivanchoTime < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanchoTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {ivanchoTime - worldRecord:f2} seconds slower.");
            }
        }
    }
}
