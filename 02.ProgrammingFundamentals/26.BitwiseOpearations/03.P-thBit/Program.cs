using System;

namespace _03.P_thBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bitAtPosition1 = input >> p & 1;
            Console.WriteLine(bitAtPosition1);
        }
    }
}
