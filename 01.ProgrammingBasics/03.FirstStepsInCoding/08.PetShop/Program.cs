using System;

namespace _08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());

            double finalPrice = (dogFood * 2.5) + (catFood * 4);
            Console.WriteLine($"{finalPrice} lv.");
        }
    }
}
