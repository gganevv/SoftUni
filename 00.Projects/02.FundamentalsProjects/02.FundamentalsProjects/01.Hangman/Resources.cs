﻿namespace _01.Hangman
{
    public static class Animation
    {
		public static string[] wrongGuesses =
{
	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"      O   ║   " + '\n' +
	@"     /|\  ║   " + '\n' +
	@"     / \  ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══",

	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"      O   ║   " + '\n' +
	@"     /|\  ║   " + '\n' +
	@"       \  ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══",

	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"      O   ║   " + '\n' +
	@"     /|\  ║   " + '\n' +
	@"          ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══",

	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"      O   ║   " + '\n' +
	@"      |\  ║   " + '\n' +
	@"          ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══",

	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"      O   ║   " + '\n' +
	@"      |   ║   " + '\n' +
	@"          ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══",

	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"      O   ║   " + '\n' +
	@"          ║   " + '\n' +
	@"          ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══",

	@"      ╔═══╗   " + '\n' +
	@"      |   ║   " + '\n' +
	@"          ║   " + '\n' +
	@"          ║   " + '\n' +
	@"          ║   " + '\n' +
	@"     ███  ║   " + '\n' +
	@"    ══════╩═══"
};
	}
    public static class Texts
    {
        public const string INTRO = ">>>HANGMAN<<<";
        public const string SELECT_DIFFICULTITY = 
@"Select difficultity.
1 - Easy >> 14 lives
2 - Medium >> 7 lives
3 - Hard >> 3 lives";
        public const string PLAY_AGAIN = "Play again? 1 = yes, 2 = no";
        public const string WIN = "You win.";
        public const string LOSE = "You lose.";
        public const string WORD_WAS = "The word was";
    }

    public static class MagicNumbers
    {
        public const int EASY_LIVES = 14;
        public const int MEDIUM_LIVES = 7;
        public const int HARD_LIVES = 3;
        public const int WAIT_TIME = 2500;
    }

    public static class ErrorMessages
    {
        public const string CANNOT_READ_FILE_ERROR = "The file could not be read:";
        public const string INVALID_KEY_ERROR = "Invalid key - try again.";
    }

    public static class FileLocation
    {
        public const string LOCATION = "words.txt";
    }

    public static class Selector
    {
        public const string SELECT1 = "1";
        public const string SELECT2 = "2";
        public const string SELECT3 = "3";
    }
}
