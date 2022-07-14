using System.Collections.Generic;

namespace _02.Judge
{
    public class User
    {
        public User(string name, int points)
        {
            Name = name;
            Points = points;
            Contests = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public int Points { get; set; }
        public Dictionary<string, int> Contests { get; set; }

        public int GetTotalPoints()
        {
            int sum = 0;
            foreach (var contest in Contests)
            {
                sum += contest.Value;
            }
            return sum;
        }
    }
}
