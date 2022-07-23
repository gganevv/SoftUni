using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();
            List<string> participantsLine = Console.ReadLine().Split(", ").ToList();
            participantsLine.ForEach(x => participants.Add(x, 0));
            string digitsPattern = @"\d";
            string namePattern = @"[A-Za-z]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var currentDistanceArr = Regex.Matches(input, digitsPattern).ToList();
                var currentNameArr = Regex.Matches(input, namePattern).ToList();
                int currentDistance = 0;
                string currentName = string.Empty;
                foreach (var digit in currentDistanceArr)
                {
                    currentDistance += int.Parse(digit.Value);
                }
                foreach (var ch in currentNameArr)
                {
                    currentName += ch;
                }
                if (participants.ContainsKey(currentName))
                {
                    participants[currentName] += currentDistance;
                }
                input = Console.ReadLine();
            }

            participants = participants.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine($"1st place: {participants.First().Key}");
            participants.Remove(participants.First().Key);
            Console.WriteLine($"2nd place: {participants.First().Key}");
            participants.Remove(participants.First().Key);
            Console.WriteLine($"3rd place: {participants.First().Key}");
        }
    }
}
