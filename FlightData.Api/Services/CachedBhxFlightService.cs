using System;
using System.Threading.Tasks;
using FlightData.Api.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FlightData.Api.Services
{
    public class CachedBhxFlightService : IFlightService
    {
        private readonly IMemoryCache _cache;

        public CachedBhxFlightService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<Flights> Load()
        {
            var bhx = new BhxFlightService();
            return await _cache.GetOrCreateAsync("bhx", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                return bhx.Load();
            });
        }
    }
}