using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int openCount = 0;
            int closeCount = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();
                if (line == "(")
                {
                    openCount++;
                }
                else if (line == ")")
                {
                    closeCount++;
                    if (openCount - closeCount != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }

            if (openCount == closeCount)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
