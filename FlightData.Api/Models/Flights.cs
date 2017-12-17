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
        private string _estimatedTime = "";
        public string EstimatedTime { get => _estimatedTime;set => _estimatedTime = FormatDate(value);}
        
        private string _scheduledTime = "";
        public string ScheduledTime { get => _scheduledTime;set => _scheduledTime = FormatDate(value);}
        
        private string _runwayTime = "";
        public string RunwayTime { get => _runwayTime;set => _runwayTime = FormatDate(value);}

        public IEnumerable<string> FlightNumbers { get; set; }
        public string Airport { get; set; }
        public IEnumerable<string> Airlines { get; set; }
        public string StatusTimeText { get; set; }
        public string Status { get; set; }

        private static string FormatDate(string date)
        {
            return date.Replace("/Date(", "").Replace(")/","");
        }
    }
}
