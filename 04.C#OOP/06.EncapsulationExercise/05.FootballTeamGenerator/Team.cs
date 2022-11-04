namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME_MESSAGE);
                }
                name = value;
            }
        }

        public int Rating => players.Count > 0 ? (int)Math.Round(players.Average(x => x.Skill)) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(x => x.Name == name);
            if (playerToRemove == null)
            {
                Console.WriteLine($"Player {name} is not in {Name} team.");
            }
            else
            {
                players.Remove(playerToRemove);
            }
        }
    }
}
