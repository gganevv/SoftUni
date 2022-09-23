using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> people = new HashSet<string>();

            HashSet<string> VIPnotComing = new HashSet<string>();
            HashSet<string> notVIPnotComing = new HashSet<string>();


            string invited = Console.ReadLine();
            while (invited != "PARTY")
            {
                people.Add(invited);

                invited = Console.ReadLine();
            }
            string coming = Console.ReadLine();
            while (coming != "END")
            {
                people.Remove(coming);

                coming = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (char.IsDigit(person[0]))
                {
                    VIPnotComing.Add(person);
                }
                else
                {
                    notVIPnotComing.Add(person);
                }
            }

            Console.WriteLine(VIPnotComing.Count + notVIPnotComing.Count);
            foreach (var person in VIPnotComing)
            {
                Console.WriteLine(person);
            }
            foreach (var person in notVIPnotComing)
            {
                Console.WriteLine(person);
            }
        }
    }
}
