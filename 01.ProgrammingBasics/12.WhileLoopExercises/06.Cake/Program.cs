using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int cakePcs = w * h;
            string command = Console.ReadLine();
            while (command != "STOP")
            {
                int takenPcs = int.Parse(command);
                cakePcs -= takenPcs;
                if (cakePcs <= 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (cakePcs < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakePcs)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cakePcs} pieces are left.");
            }
        }
    }
}
