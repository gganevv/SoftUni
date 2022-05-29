using System;

namespace _05.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int extraWorkingEmployees = int.Parse(Console.ReadLine());

            double workHours = days * 0.9 * 8;
            double extraHours = extraWorkingEmployees * 2 * days;
            double totalHours = Math.Floor(workHours + extraHours);
            double diff = totalHours - neededHours;
            if (diff >= 0)
            {
                Console.WriteLine($"Yes!{diff} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Abs(diff)} hours needed.");
            }
        }
    }
}
