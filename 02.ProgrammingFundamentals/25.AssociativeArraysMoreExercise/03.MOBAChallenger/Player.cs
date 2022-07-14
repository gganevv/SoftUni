using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.MOBAChallenger
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Position = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public Dictionary<string, int> Position { get; set; }

        public int TotalSkillPoints()
        {
            int sum = 0;
            foreach (var skill in Position)
            {
                sum += skill.Value;
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Position = Position.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            foreach (var position in Position)
            {
                sb.AppendLine($"- {position.Key} <::> {position.Value}");
            }
            return sb.ToString().Trim();
        }
    }
}
