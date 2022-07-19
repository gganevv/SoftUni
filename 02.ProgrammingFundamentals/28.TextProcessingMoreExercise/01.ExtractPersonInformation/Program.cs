using System;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            bool saveName = false;
            bool saveAge = false;

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();
                string name = string.Empty;
                string age = string.Empty;

                for (int j = 0; j < line.Length; j++)
                {
                    char currentLetter = line[j];
                    if (currentLetter == '@')
                    {
                        saveName = true;
                    }
                    if (currentLetter == '|')
                    {
                        saveName = false;
                    }
                    if (currentLetter == '#')
                    {
                        saveAge = true;
                    }
                    if (currentLetter == '*')
                    {
                        saveAge = false;
                    }

                    if (saveName && currentLetter != '@')
                    {
                        name += currentLetter;
                    }

                    if (saveAge && currentLetter != '#')
                    {
                        age += currentLetter;
                    }
                }

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
