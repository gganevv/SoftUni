using System;

namespace _05.ChallangeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int man = int.Parse(Console.ReadLine());
            int woman = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            int tablesCounter = 0;
            for (int i = 1; i <= man; i++)
            {
                for (int j = 1; j <= woman; j++)
                {
                    Console.Write($"({i} <-> {j}) ");
                    tablesCounter++;
                    if (tablesCounter >= tables)
                    {
                        return;
                    }
                }
            }
        }
    }
}
