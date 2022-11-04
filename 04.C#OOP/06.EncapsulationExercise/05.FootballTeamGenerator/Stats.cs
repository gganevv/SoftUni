namespace _05.FootballTeamGenerator
{
    using System;
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        private int Endurance
        {
            get => endurance;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_MESSAGE, nameof(Endurance)));
                }
                endurance = value;
            }
        }

        private int Sprint
        {
            get => sprint;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_MESSAGE, nameof(Sprint)));
                }
                sprint = value;
            }
        }

        private int Dribble
        {
            get => dribble;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_MESSAGE, nameof(Dribble)));
                }
                dribble = value;
            }
        }

        private int Passing
        {
            get => passing;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_MESSAGE, nameof(Passing)));
                }
                passing = value;
            }
        }

        private int Shooting
        {
            get => shooting;
            set
            {
                if (!IsStatValid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_MESSAGE, nameof(Shooting)));
                }
                shooting = value;
            }
        }

        public double Skill => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private bool IsStatValid(int stat) => stat >= 0 && stat <= 100;
    }
}
