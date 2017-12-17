using System.Threading.Tasks;
using FlightData.Api.Models;
using FlightData.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FlightData.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightsController(IMemoryCache cache, IFlightService flightService)
        {
            _flightService = flightService;
        }
        
        [HttpGet]
        [Route("arrivals")]
        public async Task<IActionResult> Arrivals()
        {
            var result = await _flightService.Load();
            return new JsonResult(FlightParser.Parse( result.Arrivals ));
        }

        [HttpGet]
        [Route("departures")]
        public async Task<IActionResult> Departures()
        {
            var result = await _flightService.Load();
            return new JsonResult(result.Departures);
        }
        [HttpGet]
        [Route("version")]
        public string Version()
        {
            return "1.0";
        }
    }
}