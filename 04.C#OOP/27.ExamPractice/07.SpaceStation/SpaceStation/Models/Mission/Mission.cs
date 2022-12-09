namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public Mission()
        {
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    astronaut.Bag.Items.Add(planet.Items.First());
                    astronaut.Breath();
                    planet.Items.Remove(planet.Items.First());
                }
            }
        }
    }
}
