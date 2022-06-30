using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double q1 = double.Parse(Console.ReadLine());
            double z1 = double.Parse(Console.ReadLine());
            double q2 = double.Parse(Console.ReadLine());
            double z2 = double.Parse(Console.ReadLine());

            double firstLineLength = FindLineLength(x1, y1, x2, y2);
            double secondLineLength = FindLineLength(q1, z1, q2, z2);

            if (firstLineLength >= secondLineLength)
            {
                FindClosest(x1, y1, x2, y2);
            }
            else
            {
                FindClosest(q1, z1, q2, z2);
            }
        }

        private static double FindLineLength(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

            return distance;
        }

        private static void FindClosest(double x1, double y1, double x2, double y2)
        {
            double firstDistance = Math.Abs(x1) + Math.Abs(y1);
            double secondDistance = Math.Abs(x2) + Math.Abs(y2);
            if (firstDistance <= secondDistance)
            {
                Console.Write($"({x1}, {y1})");
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.Write($"({x2}, {y2})");
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}
