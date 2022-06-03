using System;

namespace _03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string festiveStr = Console.ReadLine();
            bool festive = festiveStr == "Y" ? true : false;
            double totalPrice = 0;

            if (season == "Spring" || season == "Summer")
            {
                totalPrice += (chrysanthemums * 2.0) + (roses * 4.1) + (tulips * 2.5);
                if (festive)
                {
                    totalPrice *= 1.15;
                }
            }
            else
            {
                totalPrice += (chrysanthemums * 3.75) + (roses * 4.5) + (tulips * 4.15);
                if (festive)
                {
                    totalPrice *= 1.15;
                }
            }

            if (season == "Spring" && tulips > 7)
            {
                totalPrice *= 0.95;
            }
            if (season == "Winter" && roses >= 10)
            {
                totalPrice *= 0.9;
            }
            if (tulips + roses + chrysanthemums > 20)
            {
                totalPrice *= 0.8;
            }

            totalPrice += 2;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
