using System;

namespace _01.RockPaperScissorsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Rock = 1, Paper = 2, Scissors = 3;
            Console.WriteLine("Rock Paper Scissors");

            while (true)
            {
                Console.WriteLine("Chose [r]ock, [p]aper or [s]cissors:");
                string playerChoseStr = Console.ReadLine();
                int playerChose = 0;
                if (playerChoseStr == "r")
                {
                    playerChose = 1;
                }
                else if (playerChoseStr == "p")
                {
                    playerChose = 2;
                }
                else if (playerChoseStr == "s")
                {
                    playerChose = 3;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
                Random random = new Random();
                int computerChose = random.Next(1, 4);
                if (computerChose == 1)
                {
                    Console.WriteLine("Computer choice: Rock.");
                }
                else if (computerChose == 2)
                {
                    Console.WriteLine("Computer choice: Paper.");
                }
                else if (computerChose == 3)
                {
                    Console.WriteLine("Computer choice: Scissors.");
                }

                if (computerChose == playerChose)
                {
                    Console.WriteLine("Draw");
                }
                else if (playerChose == 1)
                {
                    if (computerChose == 2)
                    {
                        Console.WriteLine("You lose");
                    }
                    else if (computerChose == 3)
                    {
                        Console.WriteLine("You win");
                    }
                }
                else if (playerChose == 2)
                {
                    if (computerChose == 1)
                    {
                        Console.WriteLine("You win");
                    }
                    else if (computerChose == 3)
                    {
                        Console.WriteLine("You lose");
                    }
                }
                else if (playerChose == 3)
                {
                    if (computerChose == 1)
                    {
                        Console.WriteLine("You lose");
                    }
                    else if (computerChose == 2)
                    {
                        Console.WriteLine("You win");
                    }
                }
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
