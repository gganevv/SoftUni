using System;

namespace _07.MinNum
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int minNum = int.MaxValue;
            while (command != "Stop")
            {
                int num = int.Parse(command);
                if (minNum > num)
                {
                    minNum = num;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
