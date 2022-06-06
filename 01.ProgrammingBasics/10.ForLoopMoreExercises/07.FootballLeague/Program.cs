using System;

namespace _07.FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int fansNumber = int.Parse(Console.ReadLine());
            double a = 0;
            double b = 0;
            double v = 0;
            double g = 0;
            for (int i = 0; i < fansNumber; i++)
            {
                string sector = Console.ReadLine();
                switch (sector)
                {
                    case "A":
                        a++;
                        break;
                    case "B":
                        b++;
                        break;
                    case "V":
                        v++;
                        break;
                    case "G":
                        g++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"{a / fansNumber * 100:f2}%");
            Console.WriteLine($"{b / fansNumber * 100:f2}%");
            Console.WriteLine($"{v / fansNumber * 100:f2}%");
            Console.WriteLine($"{g / fansNumber * 100:f2}%");
            Console.WriteLine($"{(double)fansNumber / stadiumCapacity * 100:f2}%");
        }
    }
}
