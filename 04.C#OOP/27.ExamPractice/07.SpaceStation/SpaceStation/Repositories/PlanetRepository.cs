namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Planets.Contracts;
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void Add(IPlanet planet)
        {
            planets.Add(planet);
        }

        public IPlanet FindByName(string name) => planets.FirstOrDefault(x => x.Name == name);

        public bool Remove(IPlanet planet) => planets.Remove(planet);
    }
}
