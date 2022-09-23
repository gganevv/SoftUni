using System;
using System.Collections.Generic;

namespace _01.UniqueUserNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> userNames = new HashSet<string>();
            int inputNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputNumber; i++)
            {
                userNames.Add(Console.ReadLine());
            }

            foreach (var userName in userNames)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
