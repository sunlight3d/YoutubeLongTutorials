using System;

namespace apiDotNet5.Models {
    public record Location {
        public string State { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }
}