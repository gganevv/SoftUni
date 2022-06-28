using System;

namespace _05.Orders
{
    class Program
    {
        const double COFFEE_PRICE = 1.5;
        const double WATER_PRICE = 1;
        const double COKE_PRICE = 1.4;
        const double SNACKS_PRICE = 2;
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            PrintPrice(product, quantity);            
        }

        public static void PrintPrice(string product, int quantity)
        {
            double result = 0;
            switch (product)
            {
                case "coffee":
                    result = COFFEE_PRICE * quantity;
                    break;
                case "water":
                    result = WATER_PRICE * quantity;
                    break;
                case "coke":
                    result = COKE_PRICE * quantity;
                    break;
                case "snacks":
                    result = SNACKS_PRICE * quantity;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
