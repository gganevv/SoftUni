using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;
            int divCounter = 0;

            while (command != "stop")
            {
                int n = int.Parse(command);
                divCounter = 0;

                if (n < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0)
                    {
                        divCounter++;
                    }
                }

                if (divCounter == 2)
                {
                    primeSum += n;
                }
                else
                {
                    nonPrimeSum += n;
                }
                command = Console.ReadLine();
                
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
