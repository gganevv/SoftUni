using System;

namespace _01.ConvertMetersToKm
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kms = meters / 1000.0;
            Console.WriteLine($"{kms:f2}");
        }
    }
}
