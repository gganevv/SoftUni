using System;

namespace _02.SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string hour = Console.ReadLine();
            string outfit = "Shirt";
            string shoes = "Moccasins";

            if (hour == "Morning")
            {
                if (temperature >= 10 && temperature <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if(temperature >= 25)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (hour == "Afternoon")
            {
                if (temperature > 18 && temperature <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (temperature >= 25)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }

            Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
        }
    }
}
