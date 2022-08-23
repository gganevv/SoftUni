using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace _01.Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader("words.txt"))
                {
                    string[] words = streamReader.ReadToEnd().Split('\n');
                    Random random = new Random();
                    bool playing = true;
                    string difficultity = string.Empty;
                    int defaultLives = 0;
                    while (difficultity != "1" && difficultity != "2" && difficultity != "3")
                    {
                       
                        Console.Clear();
                        Console.WriteLine(">>>HANGMAN<<<");
                        Console.WriteLine("Select difficultity.");
                        Console.WriteLine("1 - Easy >> 10 lives");
                        Console.WriteLine("2 - Medium >> 6 lives");
                        Console.WriteLine("3 - Hard >> 3 lives");

                        difficultity = Console.ReadLine();
                        if (difficultity == "1")
                        {
                            defaultLives = 10;
                        }
                        else if (difficultity == "2")
                        {
                            defaultLives = 6;
                        }
                        else if (difficultity == "3")
                        {
                            defaultLives = 3;
                        }                        
                    }
                    
                    while (playing)
                    {
                        string wordFromText = words[random.Next(words.Length)].Trim();
                        List<char> word = new List<char>();
                        word.AddRange(wordFromText);

                        int lives = defaultLives;
                        string currentGuessStr = new string('_', word.Count);
                        List<char> currentGuess = new List<char>();
                        currentGuess.AddRange(currentGuessStr);
                        bool guessed = false;
                        List<char> usedLetters = new List<char>();

                        while (lives > 0 && !guessed)
                        {
                            Console.Clear();
                            Console.WriteLine($"Lives {lives}");
                            Console.WriteLine($"Guess: {string.Join("", currentGuess)}");
                            Console.WriteLine($"Used letters: {string.Join(", ", usedLetters)}");

                            char guessLetter = char.Parse(Console.ReadLine());
                            if (!usedLetters.Contains(guessLetter))
                            {
                                usedLetters.Add(guessLetter);
                            }
                            if (word.Contains(guessLetter) && !currentGuess.Contains(guessLetter))
                            {
                                for (int i = 0; i < word.Count; i++)
                                {
                                    if (word[i] == guessLetter)
                                    {
                                        currentGuess[i] = guessLetter;
                                    }
                                }
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
                        Console.Clear();
                        if (guessed)
                        {
                            Console.WriteLine("You win.");
                            Console.WriteLine($"The word was {string.Join("", word)}");
                        }
                        else
                        {
                            Console.WriteLine("You lose.");
                            Console.WriteLine($"The word was {string.Join("", word)}");
                        }
                        Thread.Sleep(5000);
                        string again = string.Empty;
                        while (again != "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Play again? 1 = yes, 2 = no");
                            again = Console.ReadLine();
                            if (again == "2")
                            {
                                playing = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
