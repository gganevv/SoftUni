namespace _02.GameOfWar
{
    public class Card
    {
        public Card(CardSuit cardSuit, CardFace cardFace)
        {
            CardSuit = cardSuit;
            CardFace = cardFace;
        }

        public CardFace CardFace { get; set; }
        public CardSuit CardSuit { get; set; }

        public override string ToString()
        {
            return $"{CardFace} of {CardSuit}";
        }
    }
}