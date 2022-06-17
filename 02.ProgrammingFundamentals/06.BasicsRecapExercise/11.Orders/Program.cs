using System;

namespace _11.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i = 0; i < orders; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double dayPrice = days * capsulesCount * capsulePrice;
                Console.WriteLine($"The price for the coffee is: ${dayPrice:f2}");
                totalPrice += dayPrice;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
