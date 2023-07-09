using HouseRentingSystem.Models.Houses;
using HouseRentingSystem.Services.House.Models;

namespace HouseRentingSystem.Contracts.House
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(string title, string address, string description, string imageUrl, decimal price, int categoryId, int agentId);
    }
}
