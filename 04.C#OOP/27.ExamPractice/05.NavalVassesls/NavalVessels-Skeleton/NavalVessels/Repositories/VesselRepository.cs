namespace NavalVessels.Repositories
{
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using System.Linq;
    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            models = new HashSet<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)models;

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public IVessel FindByName(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IVessel model) => models.Remove(model);
    }
}
