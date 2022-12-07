namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Contracts;
    using Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public bool Remove(IWeapon weapon) => weapons.Remove(weapon);

        public IWeapon FindByName(string name) => weapons.FirstOrDefault(x => x.Name == name);

    }
}