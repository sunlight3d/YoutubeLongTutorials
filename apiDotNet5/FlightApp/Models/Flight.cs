using System;
namespace FlightApp.Models {
    public record Flight {
        //init only property
        public Guid FlightId { get; init; }
        public string FlightNumber { get; init; }        
        public DateTimeOffset CreatedDate { get; init; }
        public virtual Location Source { get; init; }
        public virtual Location Destination { get; init; }        
        //virtual public ICollection<Schedule> Schedules { get; set; }

    }
}
