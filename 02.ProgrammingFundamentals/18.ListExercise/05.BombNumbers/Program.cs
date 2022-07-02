using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = command[0];
            int bombPower = command[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    for (int j = i - bombPower; j <= i + bombPower; j++)
                    {
                        if (j < 0)
                        {
                            j = 0;
                        }
                        if (j > numbers.Count - 1)
                        {
                            break;
                        }
                        numbers[j] = 0;
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
