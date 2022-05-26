using System;

namespace _01.TrapezoidArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double result = (b1 + b2) * h / 2;
            Console.WriteLine($"{result:f2}");
        }
    }
}
