using System;

namespace _01.DishWasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            int detergent = bottles * 750;
            string command = Console.ReadLine();
            int washCounter = 1;
            int dishes = 0;
            int pots = 0;

            while (command != "End")
            {
                int dishesOrPots = int.Parse(command);
                if (washCounter % 3 == 0)
                {
                    detergent -= dishesOrPots * 15;
                    pots += dishesOrPots;
                }
                else
                {
                    detergent -= dishesOrPots * 5;
                    dishes += dishesOrPots;
                }
                if (detergent < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(detergent)} ml. more necessary!");
                    break;
                }
                washCounter++;
                command = Console.ReadLine();
            }
            if (detergent >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergent} ml.");
            }
        }
    }
}
