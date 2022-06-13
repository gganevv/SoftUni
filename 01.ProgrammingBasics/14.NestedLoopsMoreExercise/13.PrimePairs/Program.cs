using System;

namespace _13.PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPair = int.Parse(Console.ReadLine());
            int secondPair = int.Parse(Console.ReadLine());
            int firstEnd = int.Parse(Console.ReadLine());
            int secondEnd = int.Parse(Console.ReadLine());

            for (int n1 = firstPair; n1 <= firstPair + firstEnd; n1++)
            {
                for (int n2 = secondPair; n2 <= secondPair + secondEnd; n2++)
                {
                    bool firstCheck = true;
                    bool secondCheck = true;
                    for (int k = 2; k <= Math.Sqrt(n1); k++)
                    {
                        if (n1 % k == 0)
                        {
                            firstCheck = false;
                            break;
                        }
                    }
                    for (int j = 2; j <= Math.Sqrt(n2); j++)
                    {
                        if (n2 % j == 0)
                        {
                            firstCheck = false;
                            break;
                        }
                    }
                    if (firstCheck && secondCheck)
                    {
                        Console.WriteLine($"{n1}{n2}");
                    }
                }
            }
            
        }
    }
}
