using System;

namespace _08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearFee = int.Parse(Console.ReadLine());
            double shoesPrice = yearFee * 0.6;
            double clothesPrice = shoesPrice * 0.8;
            double ball = clothesPrice * 0.25;
            double accesoaries = ball * 0.2;
            double totalPrice = yearFee + shoesPrice + clothesPrice + ball + accesoaries;
            Console.WriteLine(totalPrice);
        }
    }
}
