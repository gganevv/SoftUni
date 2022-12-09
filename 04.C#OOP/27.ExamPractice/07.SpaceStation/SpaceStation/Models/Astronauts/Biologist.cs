namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double INITIAL_OXYGEN = 70;
        public Biologist(string name) : base(name, INITIAL_OXYGEN)
        {
        }

        public override void Breath()
        {
            oxygen -= 5;
            if (oxygen < 0)
            {
                oxygen = 0;
            }
        }
    }
}
