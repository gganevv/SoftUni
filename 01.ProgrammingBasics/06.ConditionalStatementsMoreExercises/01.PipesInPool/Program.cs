using System;

namespace _01.PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double litersFull = p1 * h + p2 * h;
            double percentageFull = litersFull / v * 100;
            if (percentageFull <= 100)
            {
                double p1percent = p1 * h / litersFull * 100;
                double p2percent = p2 * h / litersFull * 100;
                Console.WriteLine($"The pool is {percentageFull:f2}% full. Pipe 1: {p1percent:f2}%. Pipe 2: {p2percent:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {h:f2} hours the pool overflows with {litersFull - v:f2} liters.");
            }
        }
    }
}
