namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void AddItem(IPlanet planet)
        {
            planets.Add(planet);
        }

        public IPlanet FindByName(string name) => planets.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name) => planets.Remove(FindByName(name));
    }
}
