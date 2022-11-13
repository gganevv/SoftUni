namespace Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cardsArr = Console.ReadLine().Split(", ");
            List<Card> cards = new List<Card>();
            for (int i = 0; i < cardsArr.Length; i++)
            {
                try
                {
                    string[] currentCard = cardsArr[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string cardFace = currentCard[0];
                    string cardSuit = currentCard[1];
                    Card card = CreateCard(cardFace, cardSuit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        private static Card CreateCard(string cardFace, string cardSuit)
        {
            string[] validFace = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var validSuit = new Dictionary<string, string>{
                { "S", "\u2660" },
                { "H", "\u2665" },
                { "D", "\u2666" },
                { "C", "\u2663" }
            };

            Card card;
            if (validFace.Contains(cardFace) && validSuit.ContainsKey(cardSuit))
            {
                return new Card(cardFace, validSuit[cardSuit]);
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }
}