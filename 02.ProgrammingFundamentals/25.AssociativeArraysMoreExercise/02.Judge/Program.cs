using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<User>> contests = new Dictionary<string, List<User>>();
            List<User> users = new List<User>();
            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] inputArgs = input.Split(" -> ");
                string userName = inputArgs[0];
                string contestName = inputArgs[1];
                int contestPoints = int.Parse(inputArgs[2]);
                AddContests(contests, userName, contestName, contestPoints);
                AddUsers(users, userName, contestName, contestPoints);

                input = Console.ReadLine();
            }

            PrintContests(contests);
            PrintUsers(users);
        }

        private static void PrintUsers(List<User> users)
        {
            Console.WriteLine("Individual standings:");
            int counter = 1;
            users = users.OrderByDescending(x => x.GetTotalPoints()).ThenBy(x => x.Name).ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"{counter}. {user.Name} -> {user.GetTotalPoints()}");
                counter++;
            }
        }

        private static void AddUsers(List<User> users, string userName, string contestName, int contestPoints)
        {
            if (!users.Any(x => x.Name == userName))
            {
                users.Add(new User(userName, 0));
            }
            if (!users.First(x => x.Name == userName).Contests.ContainsKey(contestName))
            {
                users.First(x => x.Name == userName).Contests.Add(contestName, contestPoints);
            }
            if (users.First(x => x.Name == userName).Contests[contestName] < contestPoints)
            {
                users.First(x => x.Name == userName).Contests[contestName] = contestPoints;
            }
        }

        private static void AddContests(Dictionary<string, List<User>> contests, string userName, string contestName, int contestPoints)
        {
            if (!contests.ContainsKey(contestName))
            {
                contests.Add(contestName, new List<User>());
            }
            if (!contests[contestName].Any(x => x.Name == userName))
            {
                contests[contestName].Add(new User(userName, contestPoints));
            }
            if (contests[contestName].First(x => x.Name == userName).Points < contestPoints)
            {
                contests[contestName].First(x => x.Name == userName).Points = contestPoints;
            }
        }

        private static void PrintContests(Dictionary<string, List<User>> contests)
        {
            foreach (var contest in contests)
            {
                int counter = 1;
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                foreach (var participant in contest.Value.OrderByDescending(x => x.Points).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{counter}. {participant.Name} <::> {participant.Points}");
                    counter++;
                }
            }
        }
    }
}
