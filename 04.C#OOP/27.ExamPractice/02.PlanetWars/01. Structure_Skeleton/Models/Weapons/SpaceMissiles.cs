namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double DEFAULT_PRICE = 8.75;
        public SpaceMissiles(int destructionLevel) : base(destructionLevel, DEFAULT_PRICE)
        {
        }
    }
}
