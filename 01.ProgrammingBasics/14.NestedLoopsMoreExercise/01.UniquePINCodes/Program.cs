using System;

namespace _01.UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= n2; j++)
                {
                    for (int k = 1; k <= n3; k++)
                    {
                        bool primeCheck = j == 2 || j == 3 || j == 5 || j == 7;
                        if (i % 2 == 0 && k % 2 == 0 && primeCheck)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
