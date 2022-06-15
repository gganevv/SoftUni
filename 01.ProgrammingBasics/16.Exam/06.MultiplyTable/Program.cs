using System;

namespace _06.MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int firstNum = int.Parse(n[2].ToString());
            int secondNum = int.Parse(n[1].ToString());
            int thirdNum = int.Parse(n[0].ToString());
            for (int i = 1; i <= firstNum; i++)
            {
                for (int j = 1; j <= secondNum; j++)
                {
                    for (int k = 1; k <= thirdNum; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
            
        }
    }
}
