namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> booths;

        public BoothRepository()
        {
            booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => booths;

        public void AddModel(IBooth booth)
        {
            booths.Add(booth);
        }
    }
}
