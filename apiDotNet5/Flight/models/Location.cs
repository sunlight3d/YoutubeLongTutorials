using System;

namespace apiDotNet5.models {
    public record Location {
        public string State { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }
}