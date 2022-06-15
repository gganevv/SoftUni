using System;

namespace _02.DearOfSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysAway = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double firstDeerFood = double.Parse(Console.ReadLine());
            double secondDeerFood = double.Parse(Console.ReadLine());
            double thirdDeerFood = double.Parse(Console.ReadLine());

            double foodNeeded = (firstDeerFood * daysAway) + (secondDeerFood * daysAway) + (thirdDeerFood * daysAway);
            double diff = Math.Abs(foodNeeded - foodLeft);
            if (foodLeft >= foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(diff)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(diff)} more kilos of food are needed.");
            }
        }
    }
}
