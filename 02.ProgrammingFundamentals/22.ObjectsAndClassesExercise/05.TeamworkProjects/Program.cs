using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            List<Team> disbandedTeams = new List<Team>();

            int teamsToCreate = int.Parse(Console.ReadLine());

            for (int i = 0; i < teamsToCreate; i++)
            {
                CreateTeam(teams);
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                AddUser(teams, input);
                input = Console.ReadLine();
            }

            disbandedTeams = teams.Where(x => x.Users.Count == 0).OrderBy(x => x.Name).ToList();
            teams.RemoveAll(x => x.Users.Count == 0);

            teams = teams.OrderByDescending(x => x.Users.Count).ThenBy(x => x.Name).ToList();
            teams.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Teams to disband:");
            disbandedTeams.ForEach(x => Console.WriteLine(x.Name));
        }

        private static void AddUser(List<Team> teams, string input)
        {
            string[] inputArgs = input.Split("->");
            string user = inputArgs[0];
            string teamName = inputArgs[1];
            bool userExists = false;

            if (!teams.Any(x => x.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
            }
            else if (teams.Any(x => x.Creator == user) || teams.Any(x => x.Users.Contains(user)))
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
            }
            else
            {
                Team team = teams.Find(x => x.Name == teamName);
                team.Users.Add(user);
            }
        }

        private static void CreateTeam(List<Team> teams)
        {
            string[] teamArgs = Console.ReadLine().Split("-");
            string user = teamArgs[0];
            string teamName = teamArgs[1];
            if (teams.Any(x => x.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
            }
            else if (teams.Any(x => x.Creator == user))
            {
                Console.WriteLine($"{user} cannot create another team!");
            }
            else
            {
                Team team = new Team(user, teamName);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }
        }
    }
}
