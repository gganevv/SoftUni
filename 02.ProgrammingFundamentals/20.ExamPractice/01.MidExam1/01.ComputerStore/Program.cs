using System;

namespace _01.ComputerStore
{
    class Program
    {
        private const double SPECIAL_DISCOUNT = 0.9;
        private const double TAX_RATE = 0.2;

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalPrice = 0;

            while (command != "special" && command != "regular")
            {
                double currentPrice = double.Parse(command);
                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }
                totalPrice += currentPrice;
                command = Console.ReadLine();
            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = totalPrice * TAX_RATE;
            double totalPriceAfterTax = totalPrice + taxes;
            if (command == "special")
            {
                totalPriceAfterTax *= SPECIAL_DISCOUNT;
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPriceAfterTax:f2}$");
        }
    }
}
