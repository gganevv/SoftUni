using System;

namespace _05.AveregeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"{sum / n:f2}");
        }
    }
}
