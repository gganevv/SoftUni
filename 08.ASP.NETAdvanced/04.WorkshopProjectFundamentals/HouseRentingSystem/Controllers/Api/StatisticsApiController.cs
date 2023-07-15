using HouseRentingSystem.Contracts.Statistic;
using HouseRentingSystem.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers.Api
{
    [ApiController]
    [Route("api/statistic")]
    public class StatisticsApiController : Controller
    {
        private readonly IStatisticService statistics;

        public StatisticsApiController(IStatisticService statistics)
        {
            this.statistics = statistics;
        }

        [HttpGet]
        public StatisticServiceModel GetStatistic()
        {
            return statistics.Total();
        }
    }
}
