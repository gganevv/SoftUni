using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                int firstCard = firstPlayer[0];
                int secondCard = secondPlayer[0];
                if (firstCard > secondCard)
                {
                    firstPlayer.Add(secondCard);
                    firstPlayer.Add(firstCard);
                }
                else if(secondCard > firstCard)
                {
                    secondPlayer.Add(firstCard);
                    secondPlayer.Add(secondCard);
                }
                firstPlayer.RemoveAt(0);
                secondPlayer.RemoveAt(0);
            }

            if (firstPlayer.Count > secondPlayer.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
    }
}
