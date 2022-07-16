using System;

namespace _02.BitAtPosition1
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitAtPosition1;
            int input = int.Parse(Console.ReadLine());
            bitAtPosition1 = input >> 1 & 1;
            Console.WriteLine(bitAtPosition1);
        }
    }
}
