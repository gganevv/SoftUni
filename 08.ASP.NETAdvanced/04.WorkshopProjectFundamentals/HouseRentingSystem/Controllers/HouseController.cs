﻿using HouseRentingSystem.Contracts.Agent;
using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Houses;
using HouseRentingSystem.Services.House.Models;
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
        public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
        {
            var queryResult = houses.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = queryResult.TotalHousesCount;
            query.Houses = queryResult.Houses;

            var houseCategories = houses.AllCategoriesNames();
            query.Categories = (IEnumerable<string>)houseCategories;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<HouseServiceModel> myHouses = null!;

            var userId = User.Id();

            if (await agents.ExistsById(userId))
            {
                var currentAgentId = await agents.GetAgentId(userId);

                myHouses = await houses.AllHousesByAgentId(currentAgentId);
            }
            else
            {
                myHouses = await houses.AllHousesByUserId(userId);
            }

            return View(myHouses);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await houses.Exists(id) == false)
            {
                return BadRequest();
            }

            var houseModel = await houses.HouseDetailsById(id);

            return View(houseModel);
        }

        public async Task<IActionResult> Add()
        {
            if (await agents.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            return View(new HouseFormModel
            {
                Categories = await houses.AllCategories()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (await agents.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            if (await houses.CategoryExists(model.CategoryId) == false)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houses.AllCategories();

                return View(model);
            }

            var agentId = await agents.GetAgentId(User.Id());

            var newHouseId = await houses.Create(model.Title, model.Address, model.Description, model.ImageUrl, model.PricePerMonth, model.CategoryId, agentId);

            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (await houses.Exists(id) == false)
            {
                return BadRequest();
            }

            if (await houses.HasAgentWithId(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }

            var house = await houses.HouseDetailsById(id);

            var houseCategoryId = houses.GetHouseCategoryId(house.Id);

            var houseModel = new HouseFormModel()
            {
                Title = house.Title,
                Address = house.Address,
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                CategoryId = houseCategoryId,
                Categories = await houses.AllCategories()
            };

            return View(houseModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel house)
        {
            if (await houses.Exists(id) == false)
            {
                return this.View();
            }

            if (await houses.HasAgentWithId(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await houses.CategoryExists(house.CategoryId) == false)
            {
                this.ModelState.AddModelError(nameof(house.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                house.Categories = await houses.AllCategories();

                return View(house);
            }

            houses.Edit(id, house.Title, house.Address, house.Description, house.ImageUrl, house.PricePerMonth, house.CategoryId);

            return RedirectToAction(nameof(Details), new { id = id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await houses.Exists(id) == false)
            {
                return BadRequest();
            }

            if (await houses.HasAgentWithId(id, User.Id()))
            {
                return Unauthorized();
            }

            var house = await houses.HouseDetailsById(id);

            var model = new HouseDetailsViewModel()
            {
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel house)
        {
            if (!await houses.Exists(house.Id))
            {
                return BadRequest();
            }

            if (!await houses.HasAgentWithId(house.Id, User.Id()))
            {
                return Unauthorized();
            }

            await houses.Delete(house.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (!await houses.Exists(id))
            {
                return BadRequest();
            }

            if (await agents.ExistsById(User.Id()))
            {
                return Unauthorized();
            }

            if (await houses.IsRented(id))
            {
                return BadRequest();
            }

            houses.Rent(id, User.Id());

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
