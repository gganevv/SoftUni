using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models.Houses;
using HouseRentingSystem.Services.House.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContex data;

        public HouseService(HouseRentingDbContex data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategories()
        {
            return await data
                .Categories
                .Select(c => new HouseCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await data.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(string title, string address, string description, string imageUrl, decimal price, int categoryId, int agentId)
        {
            var house = new HouseRentingSystem.Data.Models.House()
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = price,
                CategoryId = categoryId,
                AgentId = agentId
            };

            await data.Houses.AddAsync(house);
            await data.SaveChangesAsync();

            return house.Id;
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
