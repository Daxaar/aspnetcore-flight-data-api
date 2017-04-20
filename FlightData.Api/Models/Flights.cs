using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightData.Api.Models
{
    public class Flights
    {
        public bool Succcess { get; set; }

        [JsonIgnore] public List<Flight> Arrivals => Data.Arrivals;
        [JsonIgnore] public List<Flight> Departures => Data.Departures;

        public Data Data { get; set; }
    }

    //TODO: Write a Json converter to remove the need for this class
    public class Data
    {
        public List<Flight> Arrivals { get; set; }
        public List<Flight> Departures { get; set; }
    }
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string EstimatedTime { get; set; }
        public string ScheduledTime { get; set; }
        public string RunwayTime { get; set; }
    }
}
