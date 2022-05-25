using System;

namespace _06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int workHours = int.Parse(Console.ReadLine());
            double nylonPrice = (nylon + 2) * 1.5;
            double paintPrice = paint * 1.1 * 14.5;
            double thinnerPrice = thinner * 5;
            double bagPrice = 0.4;
            double matPrice = nylonPrice + paintPrice + thinnerPrice + bagPrice;
            double workPrice = (matPrice * 0.3) * workHours;
            double totalPrice = matPrice + workPrice;
            Console.WriteLine(totalPrice);
        }
    }
}
