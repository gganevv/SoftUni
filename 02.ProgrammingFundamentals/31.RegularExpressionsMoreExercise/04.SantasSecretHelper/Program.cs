using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04.SantasSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            string message = Console.ReadLine();
            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]+!(?<behavior>[G])!";

            while (message != "end")
            {
                string decryptedMessage = string.Empty;
                for (int i = 0; i < message.Length; i++)
                {
                    decryptedMessage += (char)(message[i] - key);
                }

                Match namesMatch = Regex.Match(decryptedMessage, pattern);
                if (namesMatch.Success)
                {
                    names.Add(namesMatch.Groups["name"].Value);
                }

                message = Console.ReadLine();
            }

            names.ForEach(Console.WriteLine);
        }
    }
}
