using System;

namespace _04.PetFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodQty = double.Parse(Console.ReadLine());

            double eatenFood = 0;
            double catEatenFood = 0;
            double dogEatenFood = 0;
            double biscuits = 0;

            for (int i = 1; i <= days; i++)
            {
                double catFoodToday = double.Parse(Console.ReadLine());
                double dogFoodToday = double.Parse(Console.ReadLine());

                catEatenFood += catFoodToday;
                dogEatenFood += dogFoodToday;
                eatenFood += catFoodToday + dogFoodToday;

                if (i % 3 == 0)
                {
                    biscuits += (catFoodToday + dogFoodToday) * 0.1;
                }
            }

            double foodEatenPercent = eatenFood / foodQty * 100;
            double catPercent = catEatenFood / eatenFood * 100;
            double dogPercent = dogEatenFood / eatenFood * 100;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{foodEatenPercent:f2}% of the food has been eaten.");
            Console.WriteLine($"{catPercent:f2}% eaten from the dog.");
            Console.WriteLine($"{dogPercent:f2}% eaten from the cat.");
        }
    }
}
