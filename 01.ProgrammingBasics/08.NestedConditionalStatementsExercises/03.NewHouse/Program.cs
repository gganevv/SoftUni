using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerNumber = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double discount = 1;
            double price = 0;

            switch (flowerType)
            {
                case "Roses":
                    price = 5;
                    discount = flowerNumber > 80 ? 0.9 : 1;
                    break;
                case "Dahlias":
                    price = 3.8;
                    discount = flowerNumber > 90 ? 0.85 : 1;
                    break;
                case "Tulips":
                    price = 2.8;
                    discount = flowerNumber > 80 ? 0.85 : 1;
                    break;
                case "Narcissus":
                    price = 3;
                    discount = flowerNumber < 120 ? 1.15 : 1;
                    break;
                case "Gladiolus":
                    price = 2.5;
                    discount = flowerNumber < 80 ? 1.2 : 1;
                    break;
                default:
                    break;
            }

            double totalPrice = price * flowerNumber * discount;
            double diff = budget - totalPrice;

            
            if (diff >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerNumber} {flowerType} and {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(diff):f2} leva more.");
            }
        }
    }
}
