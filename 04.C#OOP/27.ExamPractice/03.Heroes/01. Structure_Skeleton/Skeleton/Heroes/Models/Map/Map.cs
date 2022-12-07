
namespace Heroes.Models.Map
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Contracts;
    using Utilities;

    public class Map : IMap
    {
        private readonly List<IHero> barbarians;
        private readonly List<IHero> knights;

        public Map()
        {
            barbarians = new List<IHero>();
            knights = new List<IHero>();
        }
        public string Fight(ICollection<IHero> players)
        {
            foreach (var hero in players)
            {
                if (hero.GetType().Name == "Barbarian")
                {
                    barbarians.Add(hero);
                }
                else if (hero.GetType().Name == "Knight")
                {
                    knights.Add(hero);
                }
            }

            while (barbarians.Any(x => x.IsAlive) && knights.Any(x => x.IsAlive))
            {
                foreach (var knight in knights.Where(x => x.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }
            }

            if (barbarians.Any(x => x.IsAlive))
            {
                int aliveBarbarians = 0;
                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        aliveBarbarians++;
                    }
                }
                return string.Format(OutputMessages.BARBARIANS_WIN, aliveBarbarians);
            }
            else
            {
                int aliveknights = 0;
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        aliveknights++;
                    }
                }
                return string.Format(OutputMessages.KNIGHTS_WIN, aliveknights);
            }
        }
    }
}
