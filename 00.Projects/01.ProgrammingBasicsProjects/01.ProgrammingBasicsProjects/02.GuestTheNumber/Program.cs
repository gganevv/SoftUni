using System;

namespace _02.GuestTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {
                int counter = 0;
                int computerNumber = random.Next(1, 101);
                Console.WriteLine("Guess a number (1-100):");

                int playerNumber = int.Parse(Console.ReadLine());
                while (playerNumber != computerNumber)
                {
                    counter++;
                    if (playerNumber < computerNumber)
                    {
                        Console.WriteLine("Too low");
                    }
                    else if (playerNumber > computerNumber)
                    {
                        Console.WriteLine("Too high");
                    }
                    Console.WriteLine("Guess a number (1-100):");
                    playerNumber = int.Parse(Console.ReadLine());
                }

                Console.WriteLine($"You guessed it on the {counter} time");
                Console.WriteLine("Press [enter] to continue. [q] to quit.");
                string continuePlaying = Console.ReadLine();
                if (continuePlaying.ToLower() == "q")
                {
                    break;
                }
                Console.Clear();
            }
            
        }
    }
}
