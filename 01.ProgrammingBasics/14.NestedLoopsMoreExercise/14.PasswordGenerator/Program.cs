using System;

namespace _14.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            for (int n1 = 1; n1 <= n; n1++)
            {
                for (int n2 = 1; n2 <= n; n2++)
                {
                    for (char c1 = 'a'; c1 < 'a' + l; c1++)
                    {
                        for (char c2 = 'a'; c2 < 'a' + l; c2++)
                        {
                            for (int w = 1; w <= n; w++)
                            {
                                if (w > n1 && w > n2)
                                {
                                    Console.Write($"{n1}{n2}{(char)c1}{(char)c2}{w} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
