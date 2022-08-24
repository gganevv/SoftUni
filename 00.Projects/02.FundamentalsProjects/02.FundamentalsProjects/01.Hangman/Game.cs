using System;
using System.Collections.Generic;

namespace _01.Hangman
{
    internal class Game
    {
        internal static bool PlayAgainCheck(bool playing)
        {
            string again = string.Empty;
            while (again != Selector.SELECT1)
            {
                Console.Clear();
                Console.WriteLine(Texts.PLAY_AGAIN);
                again = Console.ReadLine();
                if (again == Selector.SELECT2)
                {
                    playing = false;
                    break;
                }
            }

            return playing;
        }

        internal static void CheckLetter(List<char> currentWord, List<char> currentGuess, char currentLetter)
        {
            for (int i = 0; i < currentWord.Count; i++)
            {
                if (currentWord[i] == currentLetter)
                {
                    currentGuess[i] = currentLetter;
                }
            }
        }

        internal static char GetCurrentChar(List<char> usedLetters)
        {
            char currentLetter;
            var input = Console.ReadKey();
            while (!Char.TryParse(input.Key.ToString(), out currentLetter))
            {
                Console.WriteLine(ErrorMessages.INVALID_KEY_ERROR);
                input = Console.ReadKey();
            }

            if (!usedLetters.Contains(currentLetter))
            {
                usedLetters.Add(currentLetter);
            }

            return currentLetter;
        }

        internal static List<char> GetWord(string[] words)
        {
            Random random = new Random();
            string wordFromText = words[random.Next(words.Length)].Trim().ToUpper();
            List<char> word = new List<char>();
            word.AddRange(wordFromText);
            return word;
        }

        internal static int DifficultitySelector()
        {
            string difficultity = string.Empty;
            int defaultLives = 0;
            while (difficultity != Selector.SELECT1 && difficultity != Selector.SELECT2 && difficultity != Selector.SELECT3)
            {

                Console.Clear();
                Console.WriteLine(Texts.INTRO);
                Console.WriteLine(Texts.SELECT_DIFFICULTITY);

                difficultity = Console.ReadLine();
                switch (difficultity)
                {
                    case Selector.SELECT1:
                        defaultLives = MagicNumbers.EASY_LIVES;
                        break;
                    case Selector.SELECT2:
                        defaultLives = MagicNumbers.MEDIUM_LIVES;
                        break;
                    case Selector.SELECT3:
                        defaultLives = MagicNumbers.HARD_LIVES;
                        break;
                }
            }
            return defaultLives;
        }
    }
}