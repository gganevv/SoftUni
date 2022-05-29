using System;

namespace _06.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double dailyDogFood = double.Parse(Console.ReadLine());
            double dailyCatFood = double.Parse(Console.ReadLine());
            double dailyTurtleFood = double.Parse(Console.ReadLine()) / 1000;

            double neededFood = (dailyDogFood + dailyCatFood + dailyTurtleFood) * days;
            double diff = food - neededFood;

            if (diff >= 0)
            {
                Console.WriteLine($"{Math.Floor(diff)} kilos of food left.");
            }
            else
            {
                diff = Math.Abs(diff);
                Console.WriteLine($"{Math.Ceiling(diff)} more kilos of food are needed.");
            }
        }
    }
}
