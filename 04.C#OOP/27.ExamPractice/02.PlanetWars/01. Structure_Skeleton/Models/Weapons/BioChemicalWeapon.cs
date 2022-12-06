namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double DEFAULT_PRICE = 3.2;
        public BioChemicalWeapon(int destructionLevel) : base(destructionLevel, DEFAULT_PRICE)
        {
        }
    }
}
