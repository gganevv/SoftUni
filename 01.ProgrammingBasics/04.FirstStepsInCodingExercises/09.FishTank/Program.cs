using System;

namespace _09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double sandPersentage = double.Parse(Console.ReadLine());

            double tankArea = length * width * height;
            double litters = tankArea / 1000;
            double littersFilled = litters * (1 - sandPersentage / 100);
            Console.WriteLine(littersFilled);
        }
    }
}
