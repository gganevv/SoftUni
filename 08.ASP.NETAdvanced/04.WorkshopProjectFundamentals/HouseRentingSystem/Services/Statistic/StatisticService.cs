using HouseRentingSystem.Contracts.Statistic;
using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly HouseRentingDbContex data;

        public StatisticService(HouseRentingDbContex data)
        {
            this.data = data;
        }

        public StatisticServiceModel Total()
        {
            var totalHouses = data.Houses.Count();
            var totalRents = data
                .Houses
                .Where(h => h.RenterId != null)
                .Count();

            return new StatisticServiceModel
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
