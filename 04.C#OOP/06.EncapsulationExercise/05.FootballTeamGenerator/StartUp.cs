
namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split(";");
                string command = inputArgs[0];
                string teamName = inputArgs[1];
                Team team = teams.FirstOrDefault(x => x.Name == teamName);
                try
                {
                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                string playerName = inputArgs[2];
                                int endurance = int.Parse(inputArgs[3]);
                                int sprint = int.Parse(inputArgs[4]);
                                int dribble = int.Parse(inputArgs[5]);
                                int passing = int.Parse(inputArgs[6]);
                                int shooting = int.Parse(inputArgs[7]);
                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                team.AddPlayer(player);
                            }
                            break;
                        case "Remove":
                            string playerToRemove = inputArgs[2];
                            team.RemovePlayer(playerToRemove);
                            break;
                        case "Rating":
                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine($"{team.Name} - {team.Rating}");
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                

                input = Console.ReadLine();
            }
        }
    }
}
