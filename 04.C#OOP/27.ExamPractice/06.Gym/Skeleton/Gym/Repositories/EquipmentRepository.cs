namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipment;

        public EquipmentRepository()
        {
            equipment = new List<IEquipment>();  
        }

        public IReadOnlyCollection<IEquipment> Models => equipment.AsReadOnly();

        public void Add(IEquipment model)
        {
            equipment.Add(model);
        }

        public bool Remove(IEquipment model) => equipment.Remove(model);

        public IEquipment FindByType(string type) => equipment.FirstOrDefault(x => x.GetType().Name == type);

    }
}