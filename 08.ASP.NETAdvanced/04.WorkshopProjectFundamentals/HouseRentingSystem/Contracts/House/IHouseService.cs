﻿using HouseRentingSystem.Infrastructure;
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

        HouseQueryServiceModel All(string category = null, string searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();
    }
}
