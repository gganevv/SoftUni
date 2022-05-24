using System;

namespace _09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double greeningMs = double.Parse(Console.ReadLine());
            double price = greeningMs * 7.61;
            double discount = price * 0.18;
            double priceAfterDiscount = price - discount;
            Console.WriteLine($"The final price is: {priceAfterDiscount} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
