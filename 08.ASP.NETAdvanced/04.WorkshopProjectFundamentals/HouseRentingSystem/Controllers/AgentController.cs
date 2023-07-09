using HouseRentingSystem.Contracts.Agent;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Agents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agents;

        public AgentController(IAgentService agents)
        {
            this.agents = agents;
        }

        public async Task<IActionResult> Become()
        {
            if (await agents.ExistsById(User.Id()))
            {
                return BadRequest();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            var userId = User.Id();

            if (await agents.ExistsById(userId))
            {
                return BadRequest();
            }

            if (await agents.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Enter another one.");
            }

            if (await agents.UserHasRents(userId))
            {
                ModelState.AddModelError("Error",
                    "You should have no rents to become an agents!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await agents.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
