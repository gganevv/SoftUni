using System;

namespace _03.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapesPerSquareMeter = double.Parse(Console.ReadLine());
            int wineLitersNeeded = int.Parse(Console.ReadLine());
            int workersNum = int.Parse(Console.ReadLine());

            double totalGrapes = vineyardArea * grapesPerSquareMeter;
            double wineProduced = totalGrapes * 0.4 / 2.5;
            double diff = wineProduced - wineLitersNeeded;
            if (diff >= 0)
            {
                int winePerWorker = (int)Math.Ceiling(diff / workersNum);
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineProduced)} liters.");
                Console.WriteLine($"{Math.Ceiling(diff)} liters left -> {winePerWorker} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(Math.Abs(diff))} liters wine needed.");
            }
        }
    }
}
