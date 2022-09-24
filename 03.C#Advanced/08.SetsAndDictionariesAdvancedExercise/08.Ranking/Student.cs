using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Ranking
{
    public class Student
    {
        public Student(string name)
        {
            Name = name;
            Contests = new List<Contest>();
        }

        public string Name { get; set; }
        public List<Contest> Contests { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Name);
            foreach (var contest in Contests.OrderByDescending(x => x.Points))
            {
                stringBuilder.AppendLine($"#  {contest.Name} -> {contest.Points}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
