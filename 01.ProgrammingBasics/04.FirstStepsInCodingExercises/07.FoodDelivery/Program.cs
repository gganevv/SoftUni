using System;

namespace _07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int veggMenus = int.Parse(Console.ReadLine());
            double totalPrice = (chickenMenus * 10.35 + fishMenus * 12.4 + veggMenus * 8.15) * 1.2 + 2.5;
            Console.WriteLine(totalPrice);
        }
    }
}
