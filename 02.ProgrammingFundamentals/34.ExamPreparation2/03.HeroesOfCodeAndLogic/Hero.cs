using System.Text;

namespace _03.HeroesOfCodeAndLogic
{
    class Hero
    {

        public Hero(string heroName, int heroHitPoints, int heroManaPoints)
        {
            Name = heroName;
            HitPoints = heroHitPoints;
            ManaPoints = heroManaPoints;
        }

        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($"  HP: {HitPoints}");
            sb.AppendLine($"  MP: {ManaPoints}");
            return sb.ToString().Trim();
        }
    }
}
