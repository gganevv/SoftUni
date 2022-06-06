using System;

namespace _05.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            double points = 0;
            double n1 = 0;
            double n2 = 0;
            double n3 = 0;
            double n4 = 0;
            double n5 = 0;
            double invalidN = 0;

            for (int i = 0; i < steps; i++)
            {
                double n = double.Parse(Console.ReadLine());
                if (n >= 0 && n < 10)
                {
                    points += n * 0.2;
                    n1++;
                }
                else if (n >= 10 && n < 20)
                {
                    points += n * 0.3;
                    n2++;
                }
                else if (n >= 20 && n < 30)
                {
                    points += n * 0.4;
                    n3++;
                }
                else if (n >= 30 && n < 40)
                {
                    points += 50;
                    n4++;
                }
                else if (n >= 40 && n <=50)
                {
                    points += 100;
                    n5++;
                }
                else if (n < 0 || n > 50)
                {
                    points *= 0.5;
                    invalidN++;
                }
            }
            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {n1 / steps * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {n2 / steps * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {n3 / steps * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {n4 / steps * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {n5 / steps * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidN / steps * 100:f2}%");
        }
    }
}
