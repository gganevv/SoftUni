using System;

namespace _10.InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n > 200 || n < 100 && n != 0)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
