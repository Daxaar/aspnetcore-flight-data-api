using System.Threading.Tasks;
using FlightData.Api.Models;
using Flurl.Http;

namespace FlightData.Api.Services
{
    public class BhxFlightService : IFlightService
    {
        public async Task<Flights> Load()
        {
            return await
                "https://www.birminghamairport.co.uk/Api/FidApi/GetFlights"
                    .AllowHttpStatus("200")
                    .PostUrlEncodedAsync(new {query = "" })
                    .ReceiveJson<Flights>();
        }
    }
}
