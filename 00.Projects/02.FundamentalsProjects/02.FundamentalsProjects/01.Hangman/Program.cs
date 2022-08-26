using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(FileLocation.LOCATION))
                {
                    string[] words = streamReader.ReadToEnd().Split('\n');
                    bool playing = true;
                    int defaultLives = Game.DifficultitySelector();
                    string difficultity = Game.GetDifficultity(defaultLives);

                    while (playing)
                    {
                        int lives = defaultLives;
                        List<char> currentWord = Game.GetWord(words);
                        List<char> currentGuess = Enumerable.Repeat('_', currentWord.Count).ToList();
                        List<char> usedLetters = new List<char>();
                        bool guessed = false;

                        while (lives > 0 && !guessed)
                        {
                            Drawler.DrawCurrentGameState(lives, currentGuess, usedLetters, difficultity);
                            char currentLetter = Game.GetCurrentChar(usedLetters);

                            if (currentWord.Contains(currentLetter) && !currentGuess.Contains(currentLetter))
                            {
                                Game.CheckLetter(currentWord, currentGuess, currentLetter);
                                if (!currentGuess.Contains('_'))
                                {
                                    guessed = true;
                                }
                            }
                            else
                            {
                                lives--;
                            }
                        }

                        Drawler.DrawResult(currentWord, guessed);
                        playing = Game.PlayAgainCheck(playing);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(ErrorMessages.CANNOT_READ_FILE_ERROR);
                Console.WriteLine(e.Message);
            }
        }
    }
}