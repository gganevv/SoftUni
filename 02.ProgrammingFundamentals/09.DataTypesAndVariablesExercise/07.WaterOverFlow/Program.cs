using System;

namespace _07.WaterOverFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TANK_CAPACITY = 255;

            int filledLiters = 0;
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                int currentFill = int.Parse(Console.ReadLine());
                if (currentFill + filledLiters > TANK_CAPACITY)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    filledLiters += currentFill;
                }
            }

            Console.WriteLine(filledLiters);
        }
    }
}
