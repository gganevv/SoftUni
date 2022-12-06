namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => militaryUnits.AsReadOnly();

        public void AddItem(IMilitaryUnit unit)
        {
            militaryUnits.Add(unit);
        }

        public IMilitaryUnit FindByName(string name) => militaryUnits.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => militaryUnits.Remove(FindByName(name));
    }
}
