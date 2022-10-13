using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => players.Count;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Name == string.Empty || player.Position == null || player.Position == string.Empty)
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                players.Add(player);
                return $"Successfully added {player.Name} to the team. Remaining open positions: {--OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                players.Remove(players.First(x => x.Name == name));
                OpenPositions++;

                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = players.RemoveAll(x => x.Position == position);
            OpenPositions += removedPlayers;

            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                Player player = players.First(x => x.Name == name);
                player.Retired = true;
                return player;
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in players)
            {
                if (player.Retired == false)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}