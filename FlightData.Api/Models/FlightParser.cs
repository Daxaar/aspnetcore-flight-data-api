using System.Collections.Generic;
using System.Linq;

namespace FlightData.Api.Models
{
    public class FlightParser
    {
        public static IEnumerable<Flight> Parse(IEnumerable<Flight> flights)
        {
            return ConsolidateFlights(flights);
        }

        private static IEnumerable<Flight> ConsolidateFlights(IEnumerable<Flight> flights)
        {
            return flights.GroupBy(
                x => x.Airport + x.ScheduledTime,
                x => x, (key, g) => new Flight
                {
                    Airline = string.Join(",",g.Select(x => x.Airline)),
                    Airlines = g.Select(x => x.Airline),
                    Airport = g.First().Airport,
                    EstimatedTime = g.First().EstimatedTime,
                    FlightNumber = string.Join(",", g.Select(x => x.FlightNumber)),
                    FlightNumbers = g.Select(x => x.FlightNumber),
                    RunwayTime = g.First().RunwayTime,
                    ScheduledTime = g.First().ScheduledTime,
                    Status = g.First().Status,
                    StatusTimeText = g.First().StatusTimeText
                });
        }
    }
}