using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messegesCount = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            string pattern = @"@(?<name>[A-Z][a-z]+)[^@\-!:>]*:\d+[^@\-!:>]*!(?<atackType>[AD])![^@\-!:>]*->\d+";

            for (int i = 0; i < messegesCount; i++)
            {
                string currentLine = Console.ReadLine();
                int decryptionKey = 0;
                string currentLineToLower = currentLine.ToLower();
                string decryptedLine = string.Empty;
                for (int j = 0; j < currentLineToLower.Length; j++)
                {
                    char currentChar = currentLineToLower[j];
                    if (currentChar == 's' || currentChar == 't' || currentChar == 'a' || currentChar == 'r')
                    {
                        decryptionKey++;
                    }
                }
                for (int k = 0; k < currentLine.Length; k++)
                {
                    decryptedLine += (char)(currentLine[k] - decryptionKey); 
                }

                var attackOrder = Regex.Match(decryptedLine, pattern);
                if (attackOrder.Success)
                {
                    if (attackOrder.Groups["atackType"].Value == "A")
                    {
                        attackedPlanets.Add(attackOrder.Groups["name"].Value);
                    }
                    else
                    {
                        destroyedPlanets.Add(attackOrder.Groups["name"].Value);
                    }
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.ForEach(x => Console.WriteLine($"-> {x}"));
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.ForEach(x => Console.WriteLine($"-> {x}"));
        }
    }
}
