using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int distance = 0;
            int battlesWon = 0;

            while (command != "End of battle")
            {
                distance = int.Parse(command);
                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    return;
                }
                energy -= distance;
                battlesWon++;
                if (battlesWon % 3 == 0)
                {
                    energy += battlesWon;
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
        }
    }
}
