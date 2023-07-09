using HouseRentingSystem.Contracts.House;
using HouseRentingSystem.Models;
using HouseRentingSystem.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houses;

        public HomeController(IHouseService houses)
        {
            this.houses = houses;
        }

        public async Task<IActionResult> Index()
        {
            var lastHouses = await houses.LastThreeHouses();
            return View(lastHouses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}