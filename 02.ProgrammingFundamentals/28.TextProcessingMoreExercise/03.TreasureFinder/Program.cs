using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> keys = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> decryptedMessages = new List<string>();
            Dictionary<string, string> treasures = new Dictionary<string, string>();
            string input = Console.ReadLine();
            

            while (input != "find")
            {
                string decryptedMessage = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    if (i >= keys.Count)
                    {
                        keys.AddRange(keys);
                    }
                    decryptedMessage += (char)(input[i] - keys[i]);
                }

                decryptedMessages.Add(decryptedMessage);

                input = Console.ReadLine();
            }

            foreach (var dm in decryptedMessages)
            {
                string treasure = string.Empty;
                string coordinates = string.Empty;
                bool findTreasure = false;
                bool findCoordinates = false;
                for (int i = 0; i < dm.Length; i++)
                {
                    char currentChar = dm[i];
                    if (currentChar == '&')
                    {
                        findTreasure = !findTreasure;
                    }
                    if (currentChar == '<')
                    {
                        findCoordinates = true;
                    }
                    if (currentChar == '>')
                    {
                        findCoordinates = false;
                    }

                    if (findTreasure && currentChar != '&')
                    {
                        treasure += currentChar;
                    }
                    if (findCoordinates && currentChar != '<')
                    {
                        coordinates += currentChar;
                    }
                }

                treasures.Add(treasure, coordinates);
            }

            foreach (var treasure in treasures)
            {
                Console.WriteLine($"Found {treasure.Key} at {treasure.Value}");
            }
        }
    }
}
