using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;
using System.Linq;

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(DataAccess.Cars);
        }

        
    }
}
