using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            string splitPattern = @"[,\s]+";
            string input = Console.ReadLine();
            List<Demon> demons = new List<Demon>();
            string[] inputDemons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();
            for (int i = 0; i < inputDemons.Length; i++)
            {
                demons.Add(new Demon(inputDemons[i]));
            }
            demons.ForEach(Console.WriteLine);
        }
    }
}
