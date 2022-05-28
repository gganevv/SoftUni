using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstResult = int.Parse(Console.ReadLine());
            int secondResult = int.Parse(Console.ReadLine());
            int thirdResult = int.Parse(Console.ReadLine());
            int totalResult = firstResult + secondResult + thirdResult;
            int mins = totalResult / 60;
            int sec = totalResult % 60;
            if (sec < 10)
            {
                Console.WriteLine($"{mins}:0{sec}");
            }
            else
            {
                Console.WriteLine($"{mins}:{sec}");
            }
        }
    }
}
