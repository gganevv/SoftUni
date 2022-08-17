using System;

namespace _02.GuestTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int computerNumber = random.Next(1, 101);
            Console.WriteLine("Guess a number (1-100):");

            int playerNumber = int.Parse(Console.ReadLine());
            while (playerNumber != computerNumber)
            {
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

            Console.WriteLine("You guessed it!");
        }
    }
}
