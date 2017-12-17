using System;
using System.Collections.Generic;
using System.Linq;
using FlightData.Api.Models;
using Xunit;

namespace FlightData.Api.Tests
{
    public class FlightDataParserTests
    {
        [Fact]
        public void RemovesStyleAttributes()
        {
            
        }

        [Fact]
        public void ConvertsDotNetDateFormatToEpoch()
        {
            
        }

        [Fact]
        public void ChangesNameOfAerLingusToComedyName()
        {
            
        }

        [Fact]
        public void WritesMergedCountWhenFightsAreGrouped()
        {
            
        }

        [Fact]
        public void WritesSourcePropertyAsDiskWhenServedFromCache()
        {
            
        }

        [Fact]
        public void GroupsFlightsWithTheSameFlightNumberAndAirline()
        {
            Flights flights = new Flights();

            flights.Data.Arrivals.AddRange(new[]
            {
                new Flight
                {
                    Airline = "Emirates",
                    FlightNumber = "F111",
                    Airport = "Glasgow",
                    ScheduledTime = "time"
                },
                new Flight
                {
                    Airline = "FlyBe",
                    FlightNumber = "F222",
                    Airport = "Glasgow",
                    ScheduledTime = "time"
                },
                new Flight
                {
                    Airline = "B1",
                    FlightNumber = "X1"
                }
            });

            FlightParser sut = new FlightParser();
            var result = FlightParser.Parse(flights.Arrivals);
            Assert.Equal(2, result.Count());
            Assert.Contains("F111", result.First().FlightNumbers);
            Assert.Contains("F222", result.First().FlightNumbers);
            Assert.Contains("Emirates",result.First().Airlines);
            Assert.Contains("FlyBe",result.First().Airlines);
        }
    }
}
