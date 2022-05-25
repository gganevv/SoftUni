using System;

namespace _05.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int cleaningDetergent = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            double penPrice = pens * 5.8;
            double markerPrice = markers * 7.2;
            double detergentPrice = cleaningDetergent * 1.2;
            double totalPrice = penPrice + markerPrice + detergentPrice;
            double priceAfterDiscount = totalPrice - (totalPrice * discount / 100);
            Console.WriteLine(priceAfterDiscount);
        }
    }
}
