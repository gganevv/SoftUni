namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;
        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();

        public void Add(IAstronaut astronaut)
        {
            astronauts.Add(astronaut);
        }

        public IAstronaut FindByName(string name) => astronauts.FirstOrDefault(x => x.Name == name);

        public bool Remove(IAstronaut astronaut) => astronauts.Remove(astronaut);
    }
}
