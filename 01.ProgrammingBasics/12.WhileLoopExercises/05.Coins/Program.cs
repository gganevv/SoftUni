using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());
            int counter = 0;
            while (change > 0)
            {
                if (change >= 2)
                {
                    change -= 2;
                }
                else if(change >= 1)
                {
                    change -= 1;
                }
                else if (change >= 0.5M)
                {
                    change -= 0.5M;
                }
                else if (change >= 0.2M)
                {
                    change -= 0.2M;
                }
                else if (change >= 0.1M)
                {
                    change -= 0.1M;
                }
                else if (change >= 0.05M)
                {
                    change -= 0.05M;
                }
                else if (change >= 0.02M)
                {
                    change -= 0.02M;
                }
                else if (change >= 0.01M)
                {
                    change -= 0.01M;
                }
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
