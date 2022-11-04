
namespace _05.FootballTeamGenerator
{
    using System;
    public class Player
    {
        private string name;
        private Stats stats;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME_MESSAGE);
                }
                name = value;
            }
        }

        public double Skill => stats.Skill;
    }
}
