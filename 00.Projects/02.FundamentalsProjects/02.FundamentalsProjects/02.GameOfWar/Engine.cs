﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GameOfWar
{
    public class Engine
    {
        internal static string Fight(List<Card> firstPlayerCards, List<Card> secondPlayerCards)
        {
            Card firstCard = firstPlayerCards[0];
            Card secondCard = secondPlayerCards[0];
            string winner = string.Empty;
            if (firstCard.CardFace > secondCard.CardFace)
            {
                winner = Texts.FIRST;
                DrawWinner(firstCard, secondCard, winner);
                firstPlayerCards.Remove(firstCard);
                secondPlayerCards.Remove(secondCard);
                firstPlayerCards.Add(firstCard);
                firstPlayerCards.Add(secondCard);
            }
            else if (firstCard.CardFace < secondCard.CardFace)
            {
                winner = Texts.SECOND;
                DrawWinner(firstCard, secondCard, winner);
                firstPlayerCards.Remove(firstCard);
                secondPlayerCards.Remove(secondCard);
                secondPlayerCards.Add(firstCard);
                secondPlayerCards.Add(secondCard);
            }
            else
            {
                ProcessWar(firstPlayerCards, secondPlayerCards);
            }

            return winner;
        }

        private static void ProcessWar(List<Card> firstPlayerCards, List<Card> secondPlayerCards)
        {
            Console.WriteLine(Texts.WAR);
            bool enoughCards = CheckEnoughCardsForWar(firstPlayerCards, secondPlayerCards);
            if (enoughCards)
            {
                List<Card> firstPlayercardsInWar = firstPlayerCards.Take(3).ToList();
                List<Card> secondPlayerCardsInWar = secondPlayerCards.Take(3).ToList();
                firstPlayerCards.RemoveRange(0, 3);
                secondPlayerCards.RemoveRange(0, 3);
                string winner = Fight(firstPlayerCards, secondPlayerCards);
                if (winner == Texts.FIRST)
                {
                    firstPlayerCards.AddRange(firstPlayercardsInWar);
                    firstPlayerCards.AddRange(secondPlayerCardsInWar);
                }
                else
                {
                    secondPlayerCards.AddRange(firstPlayercardsInWar);
                    secondPlayerCards.AddRange(secondPlayerCardsInWar);
                }
            }
            else return;
        }

        private static bool CheckEnoughCardsForWar(List<Card> firstPlayerCards, List<Card> secondPlayerCards)
        {
            if (firstPlayerCards.Count < 4)
            {
                secondPlayerCards.AddRange(firstPlayerCards);
                firstPlayerCards.Clear();
                Console.WriteLine(Texts.FIRST_PLAYER_NOT_ENOUGH_CARDS);
                return false;
            }

            if (secondPlayerCards.Count < 4)
            {
                firstPlayerCards.AddRange(secondPlayerCards);
                secondPlayerCards.Clear();
                Console.WriteLine(Texts.SECOND_PLAYER_NOT_ENOUGH_CARDS);
                return false;
            }

            return true;
        }

        private static void DrawWinner(Card firstCard, Card secondCard, string winner)
        {
            Console.WriteLine($"{Texts.FIRST_PLAYER_DRAWN}{firstCard}");
            Console.WriteLine($"{Texts.SECOND_PLAYER_DRAWN}{secondCard}");
            Console.WriteLine($"The {winner} player has won the cards!");
        }

        internal static void DrawCurrentState(List<Card> firstPlayerCards, List<Card> secondPlayerCards)
        {
            Console.WriteLine(Texts.SEPARATOR);
            Console.WriteLine($"First player currently has {firstPlayerCards.Count} cards.");
            Console.WriteLine($"Second player currently has {secondPlayerCards.Count} cards.");
            Console.WriteLine(Texts.SEPARATOR);
        }

        internal static List<Card> FillDeck()
        {
            List<Card> cards = new List<Card>();
            var faces = Enum.GetValues(typeof(CardFace));
            var suits = Enum.GetValues(typeof(CardSuit));

            foreach (CardSuit suit in suits)
            {
                foreach (CardFace face in faces)
                {
                    cards.Add(new Card(suit, face));
                }
            }

            return cards;
        }

        internal static void ShuffleDeck(List<Card> deck)
        {
            Random random = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                Card card = deck[i];
                deck.Remove(deck[i]);
                deck.Insert(random.Next(52), card);
            }
        }

        internal static void DeterminateWinner(Player firstPlayer, Player secondPlayer, int moves)
        {
            if (firstPlayer.Cards.Count == 0)
            {
                Console.WriteLine($"Second Player wins after {moves} moves!");
            }
            else if (secondPlayer.Cards.Count == 0)
            {
                Console.WriteLine($"First Player wins after {moves} moves!");
            }
        }
    }
}