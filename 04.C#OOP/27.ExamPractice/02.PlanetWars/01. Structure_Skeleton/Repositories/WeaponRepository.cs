namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void AddItem(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public IWeapon FindByName(string name) => weapons.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => weapons.Remove(FindByName(name));
    }
}
