using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputArgs = input.Split(" ");
                string vloggerName = inputArgs[0];
                string command = inputArgs[1];

                if (command == "joined")
                {
                    AddVlogger(vloggers, vloggerName);
                }
                else if (command == "followed")
                {
                    string followedVloggerName = inputArgs[2];
                    FollowVlogger(vloggers, followedVloggerName, vloggerName);
                }

                input = Console.ReadLine();
            }

            PrintStatistics(vloggers);
        }

        private static void AddVlogger(List<Vlogger> vloggers, string vloggerName)
        {
            if (!VloggerExists(vloggerName, vloggers))
            {
                vloggers.Add(new Vlogger(vloggerName));
            }
        }

        private static void FollowVlogger(List<Vlogger> vloggers, string followedVloggerName, string vloggerName)
        {
            if (VloggerExists(vloggerName, vloggers)
                && VloggerExists(followedVloggerName, vloggers)
                && vloggerName != followedVloggerName)
            {
                Vlogger vlogger = vloggers.First(x => x.Name == vloggerName);
                Vlogger followedVlogger = vloggers.First(x => x.Name == followedVloggerName);
                if (!vlogger.Following.Contains(followedVloggerName))
                {
                    vlogger.Following.Add(followedVloggerName);
                    followedVlogger.Followers.Add(vloggerName);
                }
            }
        }

        private static void PrintStatistics(List<Vlogger> vloggers)
        {
            vloggers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToList();

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int counter = 1;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{counter}. {vlogger}");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }

        private static bool VloggerExists(string vloggerName, List<Vlogger> vloggers)
        {
            return vloggers.Contains(vloggers.FirstOrDefault(x => x.Name == vloggerName));
        }
    }
}
