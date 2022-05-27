using System;

namespace _07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double area = 0;
            double a = double.Parse(Console.ReadLine());

            if (figureType == "square")
            {
                area = a * a;
            }
            else if (figureType == "rectangle")
            {
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figureType == "circle")
            {
                area = Math.PI * a * a;
            }
            else if (figureType == "triangle")
            {
                double b = double.Parse(Console.ReadLine());
                area = a * b / 2;
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
