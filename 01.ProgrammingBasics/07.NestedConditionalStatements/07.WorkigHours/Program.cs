using System;

namespace _07.WorkigHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();
            if (hour < 10 || hour > 18 || dayOfWeek == "Sunday")
            {
                Console.WriteLine("closed");
            }
            else
            {
                Console.WriteLine("open");
            }
        }
    }
}
