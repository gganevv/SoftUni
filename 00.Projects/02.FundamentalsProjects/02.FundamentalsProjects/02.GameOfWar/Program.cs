using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GameOfWar
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            List<Card> deck = Engine.FillDeck();
            Engine.ShuffleDeck(deck);
            Player firstPlayer = new Player(deck.Take(26).ToList<Card>());
            Player secondPlayer = new Player(deck.Skip(26).Take(26).ToList<Card>());
            int moves = 0;

            Console.WriteLine(Texts.WELCOME_SCREEN);

            while (firstPlayer.Cards.Count > 0 && secondPlayer.Cards.Count > 0)
            {
                Console.ReadKey();
                Engine.Fight(firstPlayer.Cards, secondPlayer.Cards);
                Engine.DrawCurrentState(firstPlayer.Cards, secondPlayer.Cards);
                moves++;
            }

            Engine.DeterminateWinner(firstPlayer, secondPlayer, moves);
        }
    }
}
