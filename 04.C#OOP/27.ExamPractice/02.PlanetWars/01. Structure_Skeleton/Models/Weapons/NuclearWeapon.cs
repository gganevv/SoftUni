namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double DEFAULT_PRICE = 15;
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, DEFAULT_PRICE)
        {
        }
    }
}
