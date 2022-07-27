using System;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string winningPattern = @"[@#$^]{6,}";
            for (int i = 0; i < tickets.Length; i++)
            {
                string currentTicket = tickets[i];
                if (currentTicket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string leftHalf = currentTicket.Substring(0, 10);
                string rightHalf = currentTicket.Substring(10, 10);
                var leftHalfCheck = Regex.Match(leftHalf, winningPattern);
                var rightHalfCheck = Regex.Match(rightHalf, winningPattern);
                if (leftHalfCheck.Value.Length >= 6 && rightHalfCheck.Value.Length >= 6 && (leftHalfCheck.Value.Contains(rightHalfCheck.Value) || rightHalfCheck.Value.Contains(leftHalfCheck.Value)))
                {
                    var winningHalf = leftHalfCheck.Value.Length < rightHalfCheck.Value.Length ? leftHalfCheck : rightHalfCheck;
                    if (leftHalfCheck.Value.Length == 10 && leftHalfCheck.Value == rightHalfCheck.Value)
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - {leftHalfCheck.Value.Length}{leftHalfCheck.Value[0]} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - {winningHalf.Value.Length}{winningHalf.Value[0]}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                }
            }
        }
    }
}
