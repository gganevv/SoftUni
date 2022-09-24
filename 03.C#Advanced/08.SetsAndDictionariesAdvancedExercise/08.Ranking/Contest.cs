namespace _08.Ranking
{
    public class Contest
    {

        public Contest(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public Contest(string name, string password, int contestPoints) : this(name, password)
        {
            Points = contestPoints;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
    }
}
