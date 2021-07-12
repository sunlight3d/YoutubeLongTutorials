using System;

namespace apiDotNet5.models {
    public record Flight {
        //init only property
        public int FlightId { get; init; }
        public string FlightNumber { get; set; }        
        public DateTimeOffset CreatedDate { get; init; }
        public virtual Location Source { get; set; }
        public virtual Location Destination { get; set; }
        //virtual public ICollection<Schedule> Schedules { get; set; }

    }
}