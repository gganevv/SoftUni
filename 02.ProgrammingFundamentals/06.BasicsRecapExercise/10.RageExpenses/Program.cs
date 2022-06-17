using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsets = lostGamesCount / 2;
            int mouses = lostGamesCount / 3;
            int keyboards = lostGamesCount / 6;
            int displays = lostGamesCount / 12;

            double rageExpenses = headsetPrice * headsets + mousePrice * mouses + keyboardPrice * keyboards + displayPrice * displays;
            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");
        }
    }
}
