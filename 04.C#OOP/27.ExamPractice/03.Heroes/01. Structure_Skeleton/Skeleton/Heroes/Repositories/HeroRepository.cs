namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();

        public void Add(IHero hero)
        {
            heroes.Add(hero);
        }

        public bool Remove(IHero hero) => heroes.Remove(hero);

        public IHero FindByName(string name) => heroes.FirstOrDefault(x => x.Name == name);

    }
}