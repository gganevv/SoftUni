using System;
using System.Collections.Generic;
using System.Threading;

namespace _01.Hangman
{
    internal class Drawler
    {
        internal static void DrawResult(List<char> currentWord, bool guessed)
        {
            Console.Clear();
            string gameResult = guessed ? Texts.WIN : Texts.LOSE;
            Console.WriteLine(gameResult);
            Console.WriteLine($"{Texts.WORD_WAS} {string.Join("", currentWord)}");

            Thread.Sleep(MagicNumbers.WAIT_TIME);
        }
        internal static void DrawCurrentGameState(int lives, List<char> currentGuess, List<char> usedLetters, string difficultity)
        {
            Console.Clear();
            DrawAnimation(lives, difficultity);
            Console.WriteLine($"Lives {lives}");
            Console.WriteLine($"Guess: {string.Join("", currentGuess)}");
            Console.WriteLine($"Used letters: {string.Join(", ", usedLetters)}");
        }

        internal static void DrawAnimation(int lives, string difficultity)
        {
            int animationNumber = lives - 1;
            if (difficultity == "hard")
            {
                animationNumber *= 2;
            }
            if (difficultity == "easy")
            {
                animationNumber /= 2;
            }

            Console.WriteLine(Animation.wrongGuesses[animationNumber]);
        }
    }
}
