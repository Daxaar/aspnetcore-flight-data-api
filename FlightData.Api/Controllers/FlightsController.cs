using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using FlightData.Api.Models;

namespace FlightData.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("arrivals")]
        public async Task<IActionResult> Arrivals()
        {
            var result = await
                "https://www.birminghamairport.co.uk/Api/FidApi/GetFlights"
                .AllowHttpStatus("200")
                .PostUrlEncodedAsync(new
                {
                    flightType = "Arrivals",
                    searchType = "Destination",
                    query = "",
                    timespan = "EightHours"
                })
                .ReceiveJson<Flights>();

            return new JsonResult(result);
        }

    }
}