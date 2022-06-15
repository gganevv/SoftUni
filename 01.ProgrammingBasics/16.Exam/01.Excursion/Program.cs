using System;

namespace _01.Excursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int cards = int.Parse(Console.ReadLine());
            int museum = int.Parse(Console.ReadLine());

            double totalPrice = (people * nights * 20.0) + (people * cards * 1.6) + (people * museum * 6.0);
            totalPrice *= 1.25;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
