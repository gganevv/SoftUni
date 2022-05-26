using System;

namespace _06.Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackerelPrice = double.Parse(Console.ReadLine());
            double spratPrice = double.Parse(Console.ReadLine());
            double bonitoKgs = double.Parse(Console.ReadLine());
            double horseMackerelKgs = double.Parse(Console.ReadLine());
            int musselKgs = int.Parse(Console.ReadLine());
            double bonitoPrice = bonitoKgs * mackerelPrice * 1.6;
            double horseMackerelPrice = horseMackerelKgs * spratPrice * 1.8;
            double musselPrice = musselKgs * 7.5;
            double total = bonitoPrice + horseMackerelPrice + musselPrice;
            Console.WriteLine($"{total:f2}");
        }
    }
}
