using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models.Houses;

namespace HouseRentingSystem.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContex data;

        public HouseService(HouseRentingDbContex data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            return data
                .Houses
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .Take(3);
        }
    }
}
