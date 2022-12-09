namespace SpaceStation.Models.Astronauts
{
    internal class Meteorologist : Astronaut
    {
        private const double INITIAL_OXYGEN = 90;

        public Meteorologist(string name) : base(name, INITIAL_OXYGEN)
        {
        }
    }
}
