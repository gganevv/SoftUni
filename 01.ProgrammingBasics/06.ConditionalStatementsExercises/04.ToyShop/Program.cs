using System;

namespace _04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzlePrice = 2.6;
            double dollPrice = 3;
            double teddyBearPrice = 4.1;
            double minionPrice = 8.2;
            double truckPrice = 2;

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzleQty = int.Parse(Console.ReadLine());
            int dollsQty = int.Parse(Console.ReadLine());
            int teddyBearsQty = int.Parse(Console.ReadLine());
            int minionsQty = int.Parse(Console.ReadLine());
            int trucksQty = int.Parse(Console.ReadLine());

            double totalPrice = (puzzlePrice * puzzleQty) + (dollPrice * dollsQty) + (teddyBearPrice * teddyBearsQty) + (minionPrice * minionsQty) + (truckPrice * trucksQty);
            int totalQty = puzzleQty + dollsQty + teddyBearsQty + minionsQty + trucksQty;
            if (totalQty >= 50)
            {
                totalPrice *= 0.75;
            }

            totalPrice *= 0.9;
            double moneyLeft = totalPrice - tripPrice;

            if (totalPrice >= tripPrice)
            {
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(moneyLeft):f2} lv needed.");
            }
        }
    }
}
