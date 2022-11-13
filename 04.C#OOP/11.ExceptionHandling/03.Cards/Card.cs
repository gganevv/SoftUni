namespace Cards
{
    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face { get; set; }
        public string Suit { get; set; }
        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}