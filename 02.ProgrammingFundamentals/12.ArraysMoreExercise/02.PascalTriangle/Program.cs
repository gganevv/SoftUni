using System;
using System.Collections.Generic;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<int> prevNums = new List<int>();
            List<int> currentNums = new List<int>();
            for (int line = 1; line <= lines; line++)
            {
                
                for (int n = 1; n <= line; n++)
                {
                    if (n > 1 && n <= prevNums.Count)
                    {
                        int currentNum = prevNums[n - 2] + prevNums[n - 1];
                        currentNums.Add(currentNum);
                        Console.Write(currentNum + " ");
                    }
                    else
                    {
                        currentNums.Add(1);
                        Console.Write(1 + " ");
                    }
                    
                }
                prevNums.Clear();
                prevNums.AddRange(currentNums);
                currentNums.Clear();
                Console.WriteLine();
            }
        }
    }
}
