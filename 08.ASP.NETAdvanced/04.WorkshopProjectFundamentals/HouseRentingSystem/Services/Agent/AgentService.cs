using HouseRentingSystem.Contracts.Agent;
using HouseRentingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContex data;

        public AgentService(HouseRentingDbContex data)
        {
            this.data = data;
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await data.Agents.AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await data.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await data.Houses.AnyAsync(h => h.RenterId == userId);
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var agent = new Data.Models.Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await data.Agents.AddAsync(agent);
            await data.SaveChangesAsync();
        }

        public async Task<int> GetAgentId(string userId)
        {
            return data.Agents.FirstOrDefault(a => a.UserId == userId).Id;
        }
    }
}
