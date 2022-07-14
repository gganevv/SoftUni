using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> playerPool = new List<Player>();

            string input = Console.ReadLine();
            while (input != "Season end")
            {
                string inputType = input.Split(" -> ").Length > 1 ? "add" : "fight";
                if (inputType == "add")
                {
                    AddPlayers(playerPool, input);
                }
                else if (inputType == "fight")
                {
                    Fight(playerPool, input);
                }

                input = Console.ReadLine();
            }
            playerPool = playerPool.OrderByDescending(x => x.TotalSkillPoints()).ThenBy(x => x.Name).ToList();

            foreach (var player in playerPool)
            {
                Console.WriteLine($"{player.Name}: {player.TotalSkillPoints()} skill");
                Console.WriteLine(player);
            }
        }

        private static void AddPlayers(List<Player> playerPool, string input)
        {
            string[] inputArgs = input.Split(" -> ");
            string playerName = inputArgs[0];
            string playerPosition = inputArgs[1];
            int playerSkill = int.Parse(inputArgs[2]);
            if (!playerPool.Any(x => x.Name == playerName))
            {
                playerPool.Add(new Player(playerName));
            }
            Player player = playerPool.First(x => x.Name == playerName);
            if (!player.Position.ContainsKey(playerPosition))
            {
                player.Position.Add(playerPosition, playerSkill);
            }
            else if (player.Position[playerPosition] < playerSkill)
            {
                player.Position[playerPosition] = playerSkill;
            }
        }

        private static void Fight(List<Player> players, string input)
        {
            string[] inputArgs = input.Split(" vs ");
            string firstPlayer = inputArgs[0];
            string secondPlayer = inputArgs[1];
            if (players.Any(x => x.Name == firstPlayer && players.Any(x => x.Name == secondPlayer)))
            {
                Player player1 = players.First(x => x.Name == firstPlayer);
                Player player2 = players.First(x => x.Name == secondPlayer);
                bool haveCommonPosition = false;
                foreach (var firstPosition in player1.Position.Keys)
                {
                    if (!haveCommonPosition)
                    {
                        foreach (var secondPosition in player2.Position.Keys)
                        {
                            if (firstPosition == secondPosition)
                            {
                                haveCommonPosition = true;
                                break;
                            }
                        }
                    }
                }

                if (haveCommonPosition)
                {
                    if (player1.TotalSkillPoints() > player2.TotalSkillPoints())
                    {
                        players.Remove(players.First(x => x.Name == player2.Name));
                    }
                    else if (player2.TotalSkillPoints() > player1.TotalSkillPoints())
                    {
                        players.Remove(players.First(x => x.Name == player1.Name));
                    }
                }
            }

        }
    }
}
