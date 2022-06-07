using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());
            string currentNum = Console.ReadLine();
            while (currentNum != "Stop")
            {
                int n = int.Parse(currentNum);
                if (n > maxNum)
                {
                    maxNum = n;
                }
                currentNum = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}
