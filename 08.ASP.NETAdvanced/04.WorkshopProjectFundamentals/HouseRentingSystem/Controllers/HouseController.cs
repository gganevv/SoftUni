using HouseRentingSystem.Contracts.Agent;
using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Houses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService houses;
        private readonly IAgentService agents;

        public HouseController(IHouseService houses, IAgentService agents)
        {
            this.houses = houses;
            this.agents = agents;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View(new AllHousesQueryModel());
        }

        public async Task<IActionResult> Mine()
        {
            return View(new AllHousesQueryModel());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(new HouseDetailsViewModel());
        }

        public async Task<IActionResult> Add()
        {
            if (await agents.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(AgentsController.Become), "Agent");
            }

            return View(new HouseFormModel
            {
                Categories = await houses.AllCategories()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(new HouseFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel house)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(new HouseFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel house)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
