using System;
using System.Collections.Generic;
using FlightApp.Models;
namespace FlightApp.Repositories {
    public class InMemoryFlightRepository {
        private readonly List<Flight> flights = new(){
          new Flight(){
              FlightId = Guid.NewGuid(),FlightNumber="a111", CreatedDate = DateTimeOffset.UtcNow,
              Source = new Location(){CountryCode=""}               
          }  
        };
    }
}