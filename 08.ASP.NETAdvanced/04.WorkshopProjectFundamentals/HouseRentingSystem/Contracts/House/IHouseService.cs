using HouseRentingSystem.Models.Houses;

namespace HouseRentingSystem.Contracts.House
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
    }
}
