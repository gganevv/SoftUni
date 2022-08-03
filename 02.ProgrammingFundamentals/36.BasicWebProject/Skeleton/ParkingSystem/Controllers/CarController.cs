using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;
using System.Linq;

namespace ParkingSystem.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            DataAccess.Cars.Add(car);

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult DeleteCar(string plateNumber)
        {
            var car = DataAccess.Cars.FirstOrDefault(x => x.PlateNumber == plateNumber);
            DataAccess.Cars.Remove(car);

            return Redirect("/");
        }
    }
}
