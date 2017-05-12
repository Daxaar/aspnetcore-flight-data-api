using System.Threading.Tasks;
using FlightData.Api.Models;

namespace FlightData.Api.Services
{
    public interface IFlightService
    {
        Task<Flights> Load();
    }
}