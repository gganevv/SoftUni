using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Ramking
{
    public class Student
    {
        public Student(string name)
        {
            Name = name;
            Contests = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public Dictionary<string, int> Contests { get; set; }
        public int GetTotalPoints() => Contests.Values.Sum();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            Contests = Contests.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            foreach (var contest in Contests)
            {
                sb.AppendLine($"#  {contest.Key} -> {contest.Value}");
            }

            return sb.ToString().Trim();
        }
    }
}
