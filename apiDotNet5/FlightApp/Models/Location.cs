using System;

namespace FlightApp.Models {
    public record Location {
        public string State { get; init; }
        public string City { get; init; }
        public ushort CountryCode { get; init; }
    }
}