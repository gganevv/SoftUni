﻿using System;

namespace _10.WeatherForecast2
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            if (degrees >= 5 && degrees < 12)
            {
                Console.WriteLine("Cold");
            }
            else if (degrees >= 12 && degrees < 15)
            {
                Console.WriteLine("Cool");
            }
            else if (degrees >= 15 && degrees <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (degrees >= 20.1 && degrees <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (degrees >= 26 && degrees <= 35)
            {
                Console.WriteLine("Hot");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
