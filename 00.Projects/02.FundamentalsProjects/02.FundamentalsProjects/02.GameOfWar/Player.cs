using System.Collections.Generic;

namespace _02.GameOfWar
{
    internal class Player
    {
        public List<Card> Cards { get; set; }

        public Player(List<Card> cards)
        {
            Cards = cards;
        }
    }
}