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
        internal static void DrawCurrentGameState(int lives, List<char> currentGuess, List<char> usedLetters)
        {
            Console.Clear();
            Console.WriteLine($"Lives {lives}");
            Console.WriteLine($"Guess: {string.Join("", currentGuess)}");
            Console.WriteLine($"Used letters: {string.Join(", ", usedLetters)}");
        }
    }
}
