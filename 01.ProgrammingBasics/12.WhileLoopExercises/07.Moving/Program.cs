using System;

namespace _07.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int space = w * l * h;

            string command = Console.ReadLine();
            while (command != "Done")
            {
                space -= int.Parse(command);
                if (space < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(space)} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (space >= 0)
            {
                Console.WriteLine($"{space} Cubic meters left.");
            }
        }
    }
}
