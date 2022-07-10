using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamworkProjects
{
    partial class Program
    {
        public class Team
        {
            public Team(string creator, string name)
            {
                Creator = creator;
                Users = new List<string>();
                Name = name;
            }
            public string Name { get; set; }
            public string Creator { get; set; }
            public List<string> Users { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Name);
                sb.AppendLine($"- {Creator}");
                foreach (var user in Users.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {user}");
                }

                return sb.ToString().Trim();
            }
        }
    }
}
