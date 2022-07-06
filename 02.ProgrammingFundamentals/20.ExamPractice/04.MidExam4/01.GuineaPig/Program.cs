using System;

namespace _01.GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());

            double foodRemain = food * 1000;
            double hayRemain = hay * 1000;
            double coverRemain = cover;

            for (int i = 1; i <= 30; i++)
            {
                foodRemain -= 300;
                if (i % 2 == 0)
                {
                    hayRemain -= foodRemain * 0.05;
                }

                if (i % 3 == 0)
                {
                    coverRemain -= weight / 3;
                }

                if (foodRemain <= 0 || hayRemain <= 0 || coverRemain <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodRemain / 1000:f2}, Hay: {hayRemain / 1000:f2}, Cover: {coverRemain:f2}.");
        }
    }
}
