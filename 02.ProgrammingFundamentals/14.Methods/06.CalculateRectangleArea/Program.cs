using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double result = CalculateArea(w, h);
            Console.WriteLine(result);
        }

        public static double CalculateArea(double w, double h) => w * h;
    }
}
