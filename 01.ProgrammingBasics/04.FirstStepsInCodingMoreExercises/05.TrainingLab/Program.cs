using System;

namespace _05.TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine()) * 100;
            double h = double.Parse(Console.ReadLine()) * 100 - 100;
            int rows = (int)(h / 70);
            int cows = (int)(w / 120);
            int seats = rows * cows - 3;
            Console.WriteLine(seats);
        }
    }
}
