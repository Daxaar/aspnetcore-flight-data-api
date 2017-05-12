using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightData.Api.Models
{
    public class Flights
    {
        public string Source { get; set; }
        public bool Success { get; set; }

        [JsonIgnore] public List<Flight> Arrivals => Data?.Arrivals;
        [JsonIgnore] public List<Flight> Departures => Data?.Departures;

        public Data Data { get; set; } = new Data();
    }

    //TODO: Write a Json converter to remove the need for this class
    public class Data
    {
        public List<Flight> Arrivals { get; set; } = new List<Flight>();
        public List<Flight> Departures { get; set; } = new List<Flight>();
    }

    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string EstimatedTime { get; set; }
        public string ScheduledTime { get; set; }
        public string RunwayTime { get; set; }
        public IEnumerable<string> FlightNumbers { get; set; }
        public string Airport { get; set; }
        public IEnumerable<string> Airlines { get; set; }
    }
}
