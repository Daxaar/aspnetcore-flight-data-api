using System.Threading.Tasks;
using FlightData.Api.Models;

namespace FlightData.Api.Controllers
{
    public interface IFlightService
    {
        Task<Flights> Load();
    }
}